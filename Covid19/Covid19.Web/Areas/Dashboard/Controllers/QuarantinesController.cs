using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19.Entities;
using Covid19.Entities.Models;
using Covid19.Web.Controllers;
using Covid19.Contracts;
using AutoMapper;
using Covid19.Web.Areas.Dashboard.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TinyCsvParser;
using System.Text;
using System.Net.Http.Headers;
using Covid19.Web.Helpers;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class QuarantinesController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public QuarantinesController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger, IWebHostEnvironment webHostEnvironment) : base(repository, mapper, logger)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Dashboard/Quarantines
        public async Task<IActionResult> Index()
        {
            return View(await this.repository.Quarantine.GetDateTimesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> DetailsByDate(DateTime date)
        {
            ViewData["datetime"] = date.ToString("dd-MM-yyyy");

            

            return View(await this.repository.Quarantine.GetQuarantinesByCreatedDateAsync(Util.ConvertDateTimeToUTC9(date)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(UploadFileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            SaveToDatabase(model);



            return RedirectToAction(nameof(Index));
        }

        // GET: Dashboard/Quarantines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarantine = await this.repository.Quarantine.FindAsync(id);
            if (quarantine == null)
            {
                return NotFound();
            }
            return View(quarantine);
        }

        // POST: Dashboard/Quarantines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Quarantine quarantine)
        {
            
            if (id != quarantine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Quarantine.Update(quarantine);
                    await this.repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuarantineExists(quarantine.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var CreatedAt = quarantine.CreatedAt;
                return RedirectToAction("DetailsByDate",new{ date= CreatedAt });
            }
            return View(quarantine);
        }

        private bool QuarantineExists(Guid id)
        {
            return this.repository.Quarantine.Exist(id);
        }



        #region Funções auxiliares

        private bool SaveToDatabase(UploadFileViewModel model)
        {
            var PERMITTED_EXTENSION_FILE = ".csv";
            var fileExtension = Path.GetExtension(model.UploadFile.FileName).ToLowerInvariant();

            string message = string.Empty;
            if (fileExtension.Equals(PERMITTED_EXTENSION_FILE))
            {


                string preferedFolderName = $"uploads/{model.SelectedDate.Year}_{model.SelectedDate.Month}_{model.SelectedDate.Day}";

                string path = Path.Combine(this.webHostEnvironment.WebRootPath, preferedFolderName);

                if (!Directory.Exists(path))
                {
                    
                    Directory.CreateDirectory(path);
                    message += "Create new directory path.<br>";
                }

                var fileName = $"{ model.SelectedDate.Year }_{ model.SelectedDate.Month}_{ model.SelectedDate.Day}_{ContentDispositionHeaderValue.Parse(model.UploadFile.ContentDisposition).FileName.Trim('"')}";

                var fullPath = Path.Combine(path, fileName);


                if (!System.IO.File.Exists(fullPath))
                {
                    message += $"{fullPath} Exist<br>";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.UploadFile.CopyTo(stream);
                    }
                    SaveQuarantineToTable(fullPath,model.SelectedDate);
                }
            }

            return false;


        }

        private void SaveQuarantineToTable(string filename,DateTime uploadDate)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvQuarantineMapping csvMapper = new CsvQuarantineMapping();
            CsvParser<QuarantineViewModel> csvParser = new CsvParser<QuarantineViewModel>(csvParserOptions, csvMapper);

            var result = csvParser.ReadFromFile(filename, Encoding.ASCII).ToList();

            foreach (var item in result)
            {
                var q = new Quarantine
                {
                    Munisipio = item.Result.Munisipio,
                    KuarentenaObrigatorio = item.Result.KuarentenaObrigatorio,
                    AutoKuarentena = item.Result.AutoKuarentena,
                    PassaQuarentena = item.Result.PassaQuarentena,
                    CreatedAt = uploadDate
                    //Total = item.Result.Total
                };

                this.repository.Quarantine.Add(q);
            }

            this.repository.Save();
        }

        #endregion
    }
}
