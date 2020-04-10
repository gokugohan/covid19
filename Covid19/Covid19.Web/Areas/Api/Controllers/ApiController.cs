using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Areas.Api.Controllers
{
    public class ApiController : Controller
    {
        protected readonly ILoggerManager loggerManager;
        protected readonly IRepositoryWrapper repository;
        protected readonly IMapper mapper;
        public ApiController(ILoggerManager loggerManager, IRepositoryWrapper repository, IMapper mapper)
        {
            this.loggerManager = loggerManager;
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}