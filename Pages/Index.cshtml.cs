using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebCommentsSection.Models;

namespace WebCommentsSection.Pages {
    public class IndexModel : PageModel {

        private readonly WebCommentsSection.Data.WebCommentsSectionContext _context;

        public IndexModel(WebCommentsSection.Data.WebCommentsSectionContext context) {
            _context = context;
        }
        public IList<Comment> Comments { get; set; }
        //public Comment IndexComment { get; set; }
        public void OnGet() {
            var comments = from c in _context.Comment
                           select c;

            Comments = comments.ToList();
        }

        [BindProperty]
        public Comment Comment { get; set; }
        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            Comment.Timestamp = DateTime.Now;
            _context.Comment.Add(Comment);
            _context.SaveChanges();

            Comment.Name = null;
            Comment.Message = null;

            return RedirectToPage("./Index");
        }
    }
}
