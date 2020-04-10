using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Covid19.Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class SettingsController : DashboardController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public SettingsController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger, IWebHostEnvironment webHostEnvironment) : base(repository, mapper, logger)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Setting
        public ActionResult Index()
        {
            var settings = this.repository.Setting.GetSettingGroups();
            return View(settings);
        }

        // POST: Setting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(IFormCollection keyValuePairs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Modelstate is invalid");
                    return RedirectToAction(nameof(Index));
                }


                var settings = new List<Setting>();
                var items = keyValuePairs.ToList();

                for (var i= 0; i<items.Count()-1;i++)
                {
                    var item = items[i];
                    var setting = this.repository.Setting.Find(m => m.Key.Equals(item.Key));
                    if (!setting.Value.Equals(item.Value))
                    {
                        setting.Value = item.Value;

                        settings.Add(setting);
                    }
                    
                }

                this.repository.Setting.UpdateRange(settings);
                this.repository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e) 
            {
                this.logger.LogWarn(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public async Task<IActionResult> UploadBanner()
        {
            try
            {
                var ret = string.Empty;
                var file = Request.Form.Files;

                var fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).FileName.Trim('"');

                string preferedFolderPath = $"uploads/banner";

                string path = Path.Combine(this.webHostEnvironment.WebRootPath, preferedFolderPath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                var webPath = Path.Combine(path, fileName);


                if (!System.IO.File.Exists(webPath))
                {
                    using FileStream stream = new FileStream(webPath, FileMode.Create);
                    var setting = await this.repository.Setting.FindAsync(m => m.Key.Equals("banner"));
                    if (setting != null)
                    {
                        file[0].CopyTo(stream);
                        ret = $"/{preferedFolderPath}/{fileName}";
                        setting.Value = ret;
                        this.repository.Setting.Update(setting);
                        await this.repository.SaveAsync();

                    }

                    stream.Flush();
                }



                return Ok(ret);
            }catch(Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}