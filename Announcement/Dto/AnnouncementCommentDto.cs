using Announcement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Announcement.ViewModel
{
    public class AnnouncementCommentDto
    {
        public Announcements Announcements { get; set; }
        public Comment Comments { get; set; }
    }
}
