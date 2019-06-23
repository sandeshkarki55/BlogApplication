using System.Threading;
using System.Threading.Tasks;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand, int>
    {
        private readonly IMyBlogDbContext _context;

        public AddCategoryCommandHandler(IMyBlogDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = command.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
