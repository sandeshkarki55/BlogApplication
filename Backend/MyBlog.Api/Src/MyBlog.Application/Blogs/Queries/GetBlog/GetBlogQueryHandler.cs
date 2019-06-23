using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BlogDetailViewModel>
    {
        private readonly IMyBlogDbContext _context;

        public GetBlogQueryHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogDetailViewModel> Handle(GetBlogQuery request)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), request.Id);
            }

            var viewModel = new BlogDetailViewModel
            {
                Id = blog.Id
            };

            return viewModel;
        }
    }
}
