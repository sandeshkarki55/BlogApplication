using MediatR;

using Microsoft.AspNetCore.Http;

using MyBlog.Application.Interfaces;
using MyBlog.Common.Helper;
using MyBlog.Domain.Entities;

using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Commands.AddBlog
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, int>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddBlogCommandHandler(IMyBlogDbContext myBlogDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _myBlogDbContext = myBlogDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            var userDetailId = _httpContextAccessor.HttpContext.User.FindFirstValue("UserDetailId");
            Blog blog = new Blog
            {
                Title = request.Title,
                Description = request.Description,
                IsDraft = request.IsDraft,
                CategoryId = request.CategoryId,
                UserDetailId = int.Parse(userDetailId)
            };

            var htmlTagStrippedDescription = HtmlStripper.StripHTML(request.Description);

            var shortDescriptionLength = htmlTagStrippedDescription.Length < 350 ? htmlTagStrippedDescription.Length : 350;
            blog.ShortDescription = htmlTagStrippedDescription.Substring(0, shortDescriptionLength);

            if (!request.IsDraft)
            {
                blog.PostedDate = DateTime.UtcNow;
            }

            await _myBlogDbContext.Blogs.AddAsync(blog);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);

            return blog.Id;
        }
    }
}
