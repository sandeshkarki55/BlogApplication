using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryListViewModel>>
    {
        private readonly IMyBlogDbContext _context;

        public GetCategoriesQueryHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryListViewModel>> Handle(GetCategoriesQuery request)
        {
            var categories = await _context.Categories.Select(x => new CategoryListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NoOfBlogs = x.Blogs.Count()
            }).ToListAsync();

            return categories;
        }
    }
}
