using Data.Announcement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Announcements : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desciption { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
    }
}
