using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnnouncementRazorPages.Pages.Announcement
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment hostingEnv;

        public CreateModel(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            this.context = context;
            this.hostingEnv = hostingEnv;
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
            if (Announcements.File != null)
            {
                //upload files to wwwroot
                var fileName = Path.GetFileName(Announcements.File.FileName);
                Announcements.FilePath = fileName;
                //judge if it is pdf file
                string ext = Path.GetExtension(Announcements.File.FileName);
                if (ext.ToLower() != ".pdf")
                {
                    return Page();
                }
                var directory = Path.Combine(hostingEnv.WebRootPath, "pdf");
                var filePath = Path.Combine(hostingEnv.WebRootPath, directory, fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await Announcements.File.CopyToAsync(fileSteam);
                }
               
                await SaveToDB();
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private async Task SaveToDB()
        {
            context.Announcements.Add(Announcements);
            await context.SaveChangesAsync();
        }
    }
}
