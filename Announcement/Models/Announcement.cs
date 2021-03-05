using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Announcement.Models
{
    public class Announcements : BaseModel
    {
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
    }
}
