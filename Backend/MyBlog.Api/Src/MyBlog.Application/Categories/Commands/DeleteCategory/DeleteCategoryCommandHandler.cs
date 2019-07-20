using MediatR;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        public const string deleteFailureMessage = "Multiple blog are associated with current category.";

        private readonly IMyBlogDbContext _context;

        public DeleteCategoryCommandHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            if (category.Blogs.Count() > 0)
            {
                throw new DeleteFailureException(nameof(Category), request.Id, deleteFailureMessage);
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
