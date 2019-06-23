using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : ICommand<int>
    {
        public string Name { get; set; }
    }
}
