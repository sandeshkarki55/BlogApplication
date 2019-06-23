
using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence
{
    public class MyBlogDbContext : DbContext, IMyBlogDbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(MyBlogDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
