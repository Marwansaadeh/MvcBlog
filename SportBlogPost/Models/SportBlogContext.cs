using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBlogPost.Models
{
    public class SportBlogContext : DbContext
    {
        public SportBlogContext()
        {
        }

        public SportBlogContext(DbContextOptions<SportBlogContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-F0J4PGB\\SQLEXPRESS; Database=SportBlog ;Trusted_Connection=True;");
            }
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

    }
}
