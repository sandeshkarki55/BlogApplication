
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Persistence
{
    public class MyBlogDbContext : IdentityDbContext<AppUser>, IMyBlogDbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(MyBlogDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
