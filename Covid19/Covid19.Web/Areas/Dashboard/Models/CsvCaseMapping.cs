using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace Covid19.Web.Areas.Dashboard.Models
{
    public class CsvCaseMapping : CsvMapping<CaseViewModel>
    {
        public CsvCaseMapping():base()
        {
            this.MapProperty(0, x => x.Kazu);
            this.MapProperty(1, x => x.Total);
            
        }
    }
}
