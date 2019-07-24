using MediatR;

namespace MyBlog.Application.Blogs.Commands.AddBlog
{
    public class AddBlogCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserDetailId { get; set; }
        public bool IsDraft { get; set; }
        public int CategoryId { get; set; }
    }
}
