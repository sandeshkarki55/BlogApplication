using MediatR;

using System.Collections.Generic;

namespace MyBlog.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogsQuery : IRequest<List<BlogListViewModel>>
    {

    }
}
