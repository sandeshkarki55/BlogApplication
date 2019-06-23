using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand:ICommand
    {
        public int Id { get; set; }
    }
}
