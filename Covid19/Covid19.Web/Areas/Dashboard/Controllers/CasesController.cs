using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19.Entities;
using Covid19.Entities.Models;
using Covid19.Contracts;
using AutoMapper;
using Covid19.Web.Areas.Dashboard.Models;
using TinyCsvParser;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Net.Http.Headers;
using Covid19.Web.Helpers;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class CasesController : DashboardController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public CasesController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger, IWebHostEnvironment webHostEnvironment) : base(repository, mapper, logger)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Dashboard/Graphs
        public async Task<IActionResult> Index()
        {
            return View(await this.repository.Graph.GetDateTimesAsync());
        }


        public async Task<IActionResult> DetailsByDate(DateTime date)
        {
            ViewData["datetime"] = date.ToString("dd-MM-yyyy");
            return View(await this.repository.Graph.GetGraphsByCreatedDateAsync(Util.ConvertDateTimeToUTC9(date)));
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

        // GET: Dashboard/Graphs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graph = await this.repository.Graph.FindAsync(id);
            if (graph == null)
            {
                return NotFound();
            }
            return View(graph);
        }

        // POST: Dashboard/Graphs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Graph graph)
        {
            if (id != graph.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Graph.Update(graph);
                    await this.repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphExists(graph.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DetailsByDate),new { date = graph.CreatedAt });
            }
            return View(graph);
        }
        private bool GraphExists(Guid id)
        {
            return this.repository.Graph.Exist(id);
        }



        #region Funções auxiliares



        private bool SaveToDatabase(UploadFileViewModel model)
        {
            var fileExtension = Path.GetExtension(model.UploadFile.FileName).ToLowerInvariant();
            var PERMITTED_EXTENSION_FILE = ".csv";

            if (fileExtension.Equals(PERMITTED_EXTENSION_FILE))
            {
                var today = DateTime.Now;

                string preferedFolderName = $"uploads/{model.SelectedDate.Year}_{model.SelectedDate.Month}_{model.SelectedDate.Day}";

                string path = Path.Combine(this.webHostEnvironment.WebRootPath, preferedFolderName);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileName = $"{ model.SelectedDate.Year }_{ model.SelectedDate.Month}_{ model.SelectedDate.Day}_{ContentDispositionHeaderValue.Parse(model.UploadFile.ContentDisposition).FileName.Trim('"')}";

                var fullPath = Path.Combine(path, fileName);


                if (!System.IO.File.Exists(fullPath))
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.UploadFile.CopyTo(stream);
                    }

                    SaveMGraphToTable(fullPath,model.SelectedDate);
                }
            }
            return false;


        }

        private void SaveMGraphToTable(string filename, DateTime uploadDate)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvCaseMapping csvMapper = new CsvCaseMapping();
            CsvParser<CaseViewModel> csvParser = new CsvParser<CaseViewModel>(csvParserOptions, csvMapper);

            var result = csvParser.ReadFromFile(filename, Encoding.ASCII).ToList();


            foreach (var item in result)
            {
                var graph = new Graph
                {
                    Kazu = item.Result.Kazu,
                    Total = item.Result.Total,
                    CreatedAt = uploadDate
                };

                this.repository.Graph.Add(graph);
            }

            this.repository.Save();
        }

        #endregion
    }
}
