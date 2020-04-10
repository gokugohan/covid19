using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("dashboard")]
    public class DashboardController : Controller
    {
        protected readonly IRepositoryWrapper repository;
        protected readonly ILoggerManager logger;
        protected readonly IMapper mapper;

        public DashboardController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

    }
}