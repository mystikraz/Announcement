using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnouncementRazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnnouncementRazorPages.Pages
{
    public class CreateCommentModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public CreateCommentModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
    }
}
