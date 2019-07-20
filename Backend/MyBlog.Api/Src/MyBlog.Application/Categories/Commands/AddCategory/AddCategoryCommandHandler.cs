using MediatR;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly IMyBlogDbContext _context;

        public AddCategoryCommandHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
