using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            Announcements = context.Announcements.ToList();
        }
    }
}
