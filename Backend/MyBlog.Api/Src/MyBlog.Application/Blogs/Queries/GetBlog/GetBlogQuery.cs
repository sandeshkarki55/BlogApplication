using MediatR;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQuery : IRequest<BlogDetailViewModel>
    {
        public int Id { get; set; }
    }
}
