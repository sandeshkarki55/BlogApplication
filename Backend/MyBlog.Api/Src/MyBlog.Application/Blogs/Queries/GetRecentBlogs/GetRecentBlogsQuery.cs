using MediatR;

using System.Collections.Generic;

namespace MyBlog.Application.Blogs.Queries.GetRecentBlogs
{
    public class GetRecentBlogsQuery : IRequest<List<RecentBlogViewModel>>
    {

    }
}
