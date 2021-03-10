using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnnouncementRazorPages.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DetailsModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Announcements Announcements { get; set; }
        [BindProperty]
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Announcements = context.Announcements.FirstOrDefault(a => a.Id == id);
            Comments = context.Comment.ToList();
            if (Announcements == null)
            {
                return NotFound();
            }
            return Page();
        }
        public JsonResult OnPost(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Data error");
            }
            SaveToDb();

            return new JsonResult("Success");
        }

        private void SaveToDb()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Comment.SenderId = userId;
            Comment.CreatedAt = DateTime.Now;
            Comment.UpdateAt = DateTime.Now;
            context.Comment.Add(Comment);
            context.SaveChanges();
        }
    }
}
