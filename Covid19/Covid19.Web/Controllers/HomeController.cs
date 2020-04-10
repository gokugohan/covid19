using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Covid19.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Covid19.Contracts;
using AutoMapper;

namespace Covid19.Web.Controllers
{
    public class HomeController : BaseController
    {
        
        public HomeController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger):
            base(repository,mapper,logger)
        {
        }

        public IActionResult Index()
        {
            
            return View();
        }


        [Route("covid-tl-map")]
        public IActionResult Covidtls()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }





    }
}
