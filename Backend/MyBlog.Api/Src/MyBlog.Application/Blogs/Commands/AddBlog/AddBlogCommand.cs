using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Blogs.Commands.AddBlog
{
    public class AddBlogCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public bool IsDraft { get; set; }
        public int CategoryId { get; set; }
    }
}
