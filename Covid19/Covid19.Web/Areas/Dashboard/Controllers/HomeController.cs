using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class HomeController : DashboardController
    {
        public HomeController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger) : base(repository, mapper, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}