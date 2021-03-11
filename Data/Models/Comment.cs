using Data.Models;
using Microsoft.AspNetCore.Identity;
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
        public virtual IdentityUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public virtual IdentityUser Receiver { get; set; }
        public int ParentId { get; set; }


    }
}
