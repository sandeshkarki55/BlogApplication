using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System;
using System.Linq;
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
            var blog = await _context.Blogs.Select(x => new BlogDetailViewModel {
                Id = x.Id,
                Description = x.Description,
                CategoryName = x.Category.Name,
                PostedDate = Convert.ToDateTime(x.PostedDate),
                Tags = x.Tags,
                Title = x.Title,
                AuthorName = x.Author.Name.FullName
            }).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (blog == null)
            {
                throw new NotFoundException(nameof(Blog), request.Id);
            }

            return blog;
        }
    }
}
