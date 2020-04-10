using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Covid19.Entities.Models
{
    public class Graph
    {

        [Key,Column("GraphId")]
        public Guid Id { get; set; }

        public string Kazu { get; set; }
        public int Total { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }

    public class GraphGroupByModel
    {
        public DateTime Group { get; set; }
        public IEnumerable<Graph> Graphs { get; set; }

    }
}
