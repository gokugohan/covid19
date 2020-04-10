using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Controllers
{
    
    public class BaseController : Controller
    {
        protected readonly IRepositoryWrapper repository;
        protected readonly ILoggerManager logger;
        protected readonly IMapper mapper;
        public BaseController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;

        }
    }
}