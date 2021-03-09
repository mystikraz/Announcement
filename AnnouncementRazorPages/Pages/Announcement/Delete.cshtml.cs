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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DeleteModel(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Announcements Announcement { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Announcement = applicationDbContext.Announcements.Find(id);
            if (Announcement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Announcement = applicationDbContext.Announcements.Find(id);
            if (Announcement != null)
            {
                applicationDbContext.Announcements.Remove(Announcement);
                applicationDbContext.SaveChanges();
            }
            return RedirectToPage("./Index");
        }
    }
}
