using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Web.Areas.Dashboard.Models
{
    public class UploadFileViewModel
    {
        [Required]
        public IFormFile UploadFile { get; set; }

        public DateTime SelectedDate { get; set; }
    }
}
