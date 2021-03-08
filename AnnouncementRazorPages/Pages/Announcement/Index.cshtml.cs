using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnnouncementRazorPages.Pages.Announcement
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IList<Announcements> Announcements { get; set; }
        public void OnGet()
        {
            try
            {
                Announcements = context.Announcements.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
