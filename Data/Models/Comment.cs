using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Comment : BaseModel
    {
        public string Description { get; set; }
        public int AnnouncementsId { get; set; }
        public virtual Announcements Announcements { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

    }
}
