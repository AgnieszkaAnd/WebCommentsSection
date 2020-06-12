using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCommentsSection.Data;
using WebCommentsSection.Models;

namespace WebCommentsSection
{
    public class DetailsModel : PageModel
    {
        private readonly WebCommentsSection.Data.WebCommentsSectionContext _context;

        public DetailsModel(WebCommentsSection.Data.WebCommentsSectionContext context)
        {
            _context = context;
        }

        public Comment Comment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment = await _context.Comment.FirstOrDefaultAsync(m => m.ID == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
