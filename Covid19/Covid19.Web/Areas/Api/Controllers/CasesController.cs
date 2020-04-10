using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covid19.Entities;
using Covid19.Entities.Models;
using Covid19.Contracts;
using AutoMapper;
using Covid19.Web.Areas.Api.Models;
using Covid19.Web.Helpers;

namespace Covid19.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ApiController
    {
        
        public CasesController(ILoggerManager loggerManager, IRepositoryWrapper repository, IMapper mapper) : base(loggerManager, repository, mapper)
        {
        }

        // GET: api/Cases
        [HttpGet(Name = "api_g_all")]

        public IList<string> Get()
        {
            return new List<string> { "/api/cases/today",
                "/api/cases/year/month/day" ,
                "/api/cases/group_by_date"
            };
        }

        // GET: api/Cases/5
        [HttpGet("today", Name = "api_g_today")]
        public async Task<IEnumerable<GraphViewModel>> GetToday()
        {

            var now = Util.ConvertDateTimeToUTC9(DateTime.Now);
            return this.mapper.Map<IEnumerable<GraphViewModel>>(await this.repository.Graph.GetGraphsByCreatedDateAsync(now));
        }

        [HttpGet("{year}/{month}/{day}", Name = "api_g_by_date")]
        public async Task<IEnumerable<GraphViewModel>> GetByDate(int year, int month, int day)
        {
            var date = new DateTime(year: year, month: month, day: day);
            var selectedDate = Util.ConvertDateTimeToUTC9(date);

            return this.mapper.Map<IEnumerable<GraphViewModel>>(await this.repository.Graph.GetGraphsByCreatedDateAsync(selectedDate));
        }

        [HttpGet("group_by_date", Name = "api_g_by_municipalities")]
        public IEnumerable<GraphGroupByModel> GroupByCreatedAt()
        {
            return this.repository.Graph.GraphsGroupByCreatedAt();
        }


    }
}
