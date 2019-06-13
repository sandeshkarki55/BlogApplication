using Microsoft.EntityFrameworkCore;

using MyBlog.DAL.Configurations;
using MyBlog.Models.Blog;

namespace MyBlog.DAL.Data
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
