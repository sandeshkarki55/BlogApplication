using MyBlog.Application.Interfaces;
using MyBlog.Common.Helper;
using MyBlog.Domain.Entities;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Blogs.Commands.AddBlog
{
    public class AddBlogCommandHandler : ICommandHandler<AddBlogCommand>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public AddBlogCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task HandleAsync(AddBlogCommand command, CancellationToken cancellationToken)
        {
            Blog blog = new Blog
            {
                Title = command.Title,
                Description = command.Description,
                IsDraft = command.IsDraft,
                CategoryId = command.CategoryId,
                UserName = command.UserName
            };

            var htmlTagStrippedDescription = HtmlStripper.StripHTML(command.Description);

            var shortDescriptionLength = htmlTagStrippedDescription.Length < 350 ? htmlTagStrippedDescription.Length : 350;
            blog.ShortDescription = htmlTagStrippedDescription.Substring(0, shortDescriptionLength);

            if (!command.IsDraft)
            {
                blog.PostedDate = DateTime.UtcNow;
            }

            await _myBlogDbContext.Blogs.AddAsync(blog);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
