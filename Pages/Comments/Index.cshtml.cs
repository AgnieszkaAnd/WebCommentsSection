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
    public class IndexModel : PageModel
    {
        private readonly WebCommentsSection.Data.WebCommentsSectionContext _context;

        public IndexModel(WebCommentsSection.Data.WebCommentsSectionContext context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; }

        public async Task OnGetAsync()
        {
            Comment = await _context.Comment.ToListAsync();
        }
    }
}
