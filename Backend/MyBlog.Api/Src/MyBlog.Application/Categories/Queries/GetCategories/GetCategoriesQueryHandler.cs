using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Categories.Models;
using MyBlog.Application.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryListViewModel>>
    {
        private readonly IMyBlogDbContext _context;

        public GetCategoriesQueryHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryListViewModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.Select(x => new CategoryListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NoOfBlogs = x.Blogs.Where(y => !y.IsDraft).Count()
            }).ToListAsync();

            return categories;
        }
    }
}
