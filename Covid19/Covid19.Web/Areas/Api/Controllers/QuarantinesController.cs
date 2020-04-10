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
    public class QuarantinesController : ApiController
    {
        
        public QuarantinesController(ILoggerManager loggerManager, IRepositoryWrapper repository, IMapper mapper) : base(loggerManager, repository, mapper)
        {
        }

        // GET: api/Cases
        [HttpGet]
        public IList<string> Get()
        {
            return new List<string> { 
                "/api/quarantines/today", 
                "/api/quarantines/year/month/day",
                "/api/quarantines/group_by_date",
                "/api/quarantines/group_by_municipio"
            };

        }

        // GET: api/Cases/5
        [HttpGet("today")]
        public async Task<IEnumerable<QuarantineViewModel>> GetToday()
        {
            var now = Util.ConvertDateTimeToUTC9(DateTime.Now);
            
            return this.mapper.Map<IEnumerable<QuarantineViewModel>>(await this.repository.Quarantine.GetQuarantinesByCreatedDateAsync(now));
        }


        [HttpGet("{year}/{month}/{day}")]
        public IEnumerable<QuarantineViewModel> GetByDate(int year, int month, int day)
        {
            var date = new DateTime(year: year, month: month, day: day);
            var selectedDate = Util.ConvertDateTimeToUTC9(date);

            var result = this.repository.Quarantine.GetQuarantinesByCreatedDate(selectedDate);
            return this.mapper.Map<IEnumerable<QuarantineViewModel>>(result);
        }



        [HttpGet("group_by_date")]
        public IEnumerable<QuarantineGroupByDateViewModel> GroupByCreatedAt()
        {
            return this.mapper.Map<IEnumerable<QuarantineGroupByDateViewModel>>(this.repository.Quarantine.QuarantinesGroupByCreatedAt());
        }

        [HttpGet("group_by_municipio")]
        public IEnumerable<QuarantineGroupMunicipioteViewModel> GroupByMunicipio()
        {
            return this.mapper.Map<IEnumerable<QuarantineGroupMunicipioteViewModel>>(this.repository.Quarantine.QuarantinesGroupByMunicipio());
        }

    }
}
