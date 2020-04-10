using System;
using System.Collections.Generic;

namespace Covid19.Web.Areas.Api.Models
{
    public class QuarantineViewModel
    {
        public string Munisipio { get; set; }
        public int Obrigatorio { get; set; }
        public int Auto { get; set; }
        public int Passa { get; set; }
        public string Data { get; set; }

    }



    public class QuarantineGroupByDateViewModel
    {
        public DateTime Key { get; set; }
        public IEnumerable<QuarantineViewModel> Data { get; set; }

    }

    public class QuarantineGroupMunicipioteViewModel
    {
        public string Key { get; set; }
        public IEnumerable<QuarantineViewModel> Data { get; set; }

    }

}