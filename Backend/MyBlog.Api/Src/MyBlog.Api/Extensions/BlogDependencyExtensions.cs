using Microsoft.Extensions.DependencyInjection;

using MyBlog.Application.Blogs.Commands.AddBlog;
using MyBlog.Application.Blogs.Queries.GetBlog;
using MyBlog.Application.Blogs.Queries.GetBlogs;
using MyBlog.Application.Blogs.Queries.GetRecentBlogs;
using MyBlog.Application.Interfaces;

using System.Collections.Generic;

namespace MyBlog.API.Extensions
{
    public static class BlogDependencyExtensions
    {
        public static IServiceCollection RegisterBlogDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetBlogsQuery, List<BlogListViewModel>>, GetBlogsQueryHandler>();
            services.AddScoped<IRequestHandler<GetBlogQuery, BlogDetailViewModel>, GetBlogQueryHandler>();
            services.AddScoped<IRequestHandler<GetRecentBlogsQuery, List<RecentBlogViewModel>>, GetRecentBlogsQueryHandler>();

            services.AddScoped<ICommandHandler<AddBlogCommand>, AddBlogCommandHandler>();

            return services;
        }
    }
}
