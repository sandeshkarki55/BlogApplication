using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BlogDetailViewModel>
    {
        private readonly IMyBlogDbContext _context;

        public GetBlogQueryHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogDetailViewModel> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _context.Blogs.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), request.Id);
            }

            var viewModel = new BlogDetailViewModel
            {
                Id = blog.Id,
                Description = blog.Description,
                CategoryName = blog.Category.Name,
                PostedDate = Convert.ToDateTime(blog.PostedDate),
                Tags = blog.Tags,
                Title = blog.Title,
                UserName = blog.UserName
            };

            return viewModel;
        }
    }
}
