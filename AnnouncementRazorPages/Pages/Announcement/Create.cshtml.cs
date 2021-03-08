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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        [BindProperty]
        public Announcements Announcements { get; set; }
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await SaveToDB();
            return RedirectToPage("./Index");
        }

        private async Task SaveToDB()
        {
            context.Announcements.Add(Announcements);
            await context.SaveChangesAsync();
        }
    }
}
