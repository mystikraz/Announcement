using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext context;

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        public IList<Announcements> Announcements { get; set; }

        public void OnGet()
        {
            Announcements = (from announcement in context.Announcements
                             join user in context.Users
                             on announcement.CreatedBy equals user.Id
                             select new Announcements
                             {
                                 Title = announcement.Title,
                                 Id = announcement.Id,
                                 CreatedBy = user.UserName,
                                 CreatedAt = announcement.CreatedAt,
                                 Desciption = announcement.Desciption,
                             }).ToList();

            //Announcements = context.Announcements.Include(x => x.CreatedBy).ToList();
        }
    }
}
