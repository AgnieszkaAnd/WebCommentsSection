using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCommentsSection.Models;

namespace WebCommentsSection.Data
{
    public class WebCommentsSectionContext : DbContext
    {
        public WebCommentsSectionContext (DbContextOptions<WebCommentsSectionContext> options)
            : base(options)
        {
        }

        public DbSet<WebCommentsSection.Models.Comment> Comment { get; set; }
    }
}
