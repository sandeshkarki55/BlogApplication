using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogListViewModel>>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public GetBlogsQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<List<BlogListViewModel>> Handle(GetBlogsQuery request)
        {
            var blogs = await _myBlogDbContext.Blogs.Where(x => !x.IsDraft).Include(x => x.Category).Select(x => new BlogListViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CategoryName = x.Category.Name,
                PostedDate = Convert.ToDateTime(x.PostedDate),
                ShortDescription = x.ShortDescription,
                Tags = x.Tags,
                UserName = x.UserId
            }).ToListAsync();

            return blogs;
        }
    }
}
