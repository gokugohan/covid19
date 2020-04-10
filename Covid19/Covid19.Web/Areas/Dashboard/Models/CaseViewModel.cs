using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Web.Areas.Dashboard.Models
{
    public class CaseViewModel
    {
        public Guid Id { get; set; }

        public string Kazu { get; set; }
        public int Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
