using Microsoft.EntityFrameworkCore;

using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface IMyBlogDbContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<UserDetail> UserDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
