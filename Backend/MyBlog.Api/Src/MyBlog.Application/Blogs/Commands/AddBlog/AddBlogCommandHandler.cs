using MediatR;

using MyBlog.Application.Interfaces;
using MyBlog.Common.Helper;
using MyBlog.Domain.Entities;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Commands.AddBlog
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, int>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public AddBlogCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<int> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog
            {
                Title = request.Title,
                Description = request.Description,
                IsDraft = request.IsDraft,
                CategoryId = request.CategoryId,
                //UserName = request.UserName
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
