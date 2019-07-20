using MediatR;

namespace MyBlog.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
