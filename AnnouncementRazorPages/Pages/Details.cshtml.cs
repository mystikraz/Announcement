using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnnouncementRazorPages.Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            //Comments = context.Comment.ToList();
            if (Announcements == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnGetComments(int? id)
        {
            var comments = from comment in context.Comment  // select id, desciption, users.Id, users.name, users.email, from comment as comment join aspnetusers as users on comment.senderId=users.userId 
                           join user in context.Users
                           on comment.SenderId equals user.Id
                           select new Comment
                           {
                               Id = comment.Id,
                               Description = comment.Description,
                               Sender = user,
                               CreatedAt = comment.CreatedAt,
                               ParentId = comment.ParentId,
                               AnnouncementsId=comment.AnnouncementsId
                           };


            Comments = comments.ToList().Where(c => c.ParentId == 0 && c.AnnouncementsId == id).ToList();
            if (Comments == null)
            {
                return new JsonResult("Not Found");
            }
            return new JsonResult(Comments);
        }
        public IActionResult OnGetCommentById(int? id)
        {
            var comments = from comment in context.Comment
                           join user in context.Users
                           on comment.SenderId equals user.Id
                           select new Comment
                           { Id = comment.Id, Description = comment.Description, Sender = user, CreatedAt = comment.CreatedAt, ParentId = comment.ParentId };
            Comments = comments.ToList().Where(c => c.ParentId == id).ToList();
            if (Comments == null)
            {
                return new JsonResult("Not Found");
            }
            return new JsonResult(Comments);
        }
        public JsonResult OnPostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Data error");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return new JsonResult("user Not LoggedIn");
            }
            SaveToDb(comment, userId);

            return new JsonResult("Success");
        }

        private void SaveToDb(Comment comment, string userId)
        {
            comment.SenderId = userId;
            comment.CreatedAt = DateTime.Now;
            comment.UpdateAt = DateTime.Now;
            context.Comment.Add(comment);
            context.SaveChanges();
        }
    }
}
