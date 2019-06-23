using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class GetBlogQuery:IRequest<BlogDetailViewModel>
    {
        public int Id { get; set; }
    }
}
