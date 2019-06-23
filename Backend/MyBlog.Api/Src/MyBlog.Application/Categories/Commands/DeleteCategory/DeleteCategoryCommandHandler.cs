using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly IMyBlogDbContext _context;

        public DeleteCategoryCommandHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(command.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), command.Id);
            }

            if (category.Blogs.Count() > 0)
            {
                const string deleteFailureMessage = "Multiple blog are associated with current category.";
                throw new DeleteFailureException(nameof(Category), command.Id, deleteFailureMessage);
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
