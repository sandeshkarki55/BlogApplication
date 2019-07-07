using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDetailViewModel>
    {
        private readonly IMyBlogDbContext _context;

        public GetCategoryQueryHandler(IMyBlogDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryDetailViewModel> HandleAsync(GetCategoryQuery request)
        {
            var category = await _context.Categories.Select(x => new CategoryDetailViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NoOfBlogs = x.Blogs.Count()
            }).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return category;
        }
    }
}
