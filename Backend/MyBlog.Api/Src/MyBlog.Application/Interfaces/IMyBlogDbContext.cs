using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Interfaces
{
    public interface IMyBlogDbContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
