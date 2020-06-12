using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebCommentsSection.Data;

namespace WebCommentsSection.Models {
    public class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new WebCommentsSectionContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebCommentsSectionContext>>())) {
                // Look for any movies.
                if (context.Comment.Any()) {
                    return;   // DB has been seeded
                }

                context.Comment.AddRange(
                    new Comment {
                        Name = "Alex",
                        Message = "Good job!",
                        Timestamp = DateTime.Parse("2020-6-11"),
                    },

                    new Comment {
                        Name = "Anna",
                        Message = "Hello!",
                        Timestamp = DateTime.Parse("2020-6-12"),
                    },

                    new Comment {
                        Name = "Alice",
                        Message = "I will be happy to join the team",
                        Timestamp = DateTime.Parse("2020-6-12"),
                    },

                    new Comment {
                        Name = "Eddie",
                        Message = "Greetings",
                        Timestamp = DateTime.Parse("2020-6-12"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
