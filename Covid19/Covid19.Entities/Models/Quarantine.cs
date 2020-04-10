using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Covid19.Entities.Models
{
    public class Quarantine
    {

        [Key,Column("QuarantineId")]
        public Guid Id { get; set; }
        public string Munisipio { get; set; }
        public int KuarentenaObrigatorio { get; set; }
        public int AutoKuarentena { get; set; }
        public int PassaQuarentena { get; set; }
        //public int Total { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }

    public class QuarantineGroupByDateModel
    {
        public DateTime Group { get; set; }
        public IEnumerable<Quarantine> Quarantines { get; set; }

    }

    public class QuarantineGroupMunicipioteModel
    {
        public string Group { get; set; }
        public IEnumerable<Quarantine> Quarantines { get; set; }

    }

}
