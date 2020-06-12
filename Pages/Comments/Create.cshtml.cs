using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCommentsSection.Data;
using WebCommentsSection.Models;

namespace WebCommentsSection
{
    public class CreateModel : PageModel
    {
        private readonly WebCommentsSection.Data.WebCommentsSectionContext _context;

        public CreateModel(WebCommentsSection.Data.WebCommentsSectionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
