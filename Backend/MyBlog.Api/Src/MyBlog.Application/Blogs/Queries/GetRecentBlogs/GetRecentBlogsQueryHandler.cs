using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Queries.GetRecentBlogs
{
    public class GetRecentBlogsQueryHandler : IRequestHandler<GetRecentBlogsQuery, List<RecentBlogViewModel>>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public GetRecentBlogsQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<List<RecentBlogViewModel>> Handle(GetRecentBlogsQuery request)
        {
            var recentBlogs = await _myBlogDbContext.Blogs.Where(x => !x.IsDraft).OrderBy(x => x.PostedDate).Select(x => new RecentBlogViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).Take(5).ToListAsync();

            return recentBlogs;
        }
    }
}
