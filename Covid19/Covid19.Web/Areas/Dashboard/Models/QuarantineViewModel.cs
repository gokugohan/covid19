using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Web.Areas.Dashboard.Models
{
    public class QuarantineViewModel
    {
        public Guid Id { get; set; }
        public string Munisipio { get; set; }
        public int KuarentenaObrigatorio { get; set; }
        public int AutoKuarentena { get; set; }
        public int PassaQuarentena { get; set; }
        //public int Total { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
