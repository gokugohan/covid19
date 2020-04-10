using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Covid19.Entities.Models
{
    public class Setting
    {
        [Key,Column("SettingId")]
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }


    public class SettingGroupModel
    {
        public string Group { get; set; }
        public IEnumerable<Setting> Settings { get; set; }

    }
}
