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
        
        [BindProperty]
        public Comment Comment { get; set; }
        
        
        public void OnGet() {
            var comments = from c in _context.Comment
                           orderby c.Timestamp descending
                           select c;

            Comments = comments.ToList();
        }

        public IActionResult OnPost() { // moznaby tutaj dodac Comment jako parametr OnPost(Comment Comment)
            if (!ModelState.IsValid) {
                // may save that in session variable but it uses server memory too much 
                var comments = from c in _context.Comment
                               orderby c.Timestamp descending
                               select c;

                Comments = comments.ToList();
                
                //Request - instancja, która jest dostępna w obu metodach - OnGet i OnPost
                //Request.HttpContext.WebSockets - POBAWIC SIE TYM !!! 

                return Page(); // async - podanie tylko 1 części strony do przeładowania
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
