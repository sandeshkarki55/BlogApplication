using Microsoft.Extensions.DependencyInjection;

using MyBlog.Application.Blogs.Commands.AddBlog;
using MyBlog.Application.Blogs.Queries.GetBlog;
using MyBlog.Application.Blogs.Queries.GetBlogs;
using MyBlog.Application.Interfaces;

using System.Collections.Generic;

namespace MyBlog.API.Extensions
{
    public static class BlogDependencyExtensions
    {
        public static IServiceCollection RegisterBlogDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetBlogsQuery, List<BlogListViewModel>>, GetBlogsQueryHandler>();
            services.AddScoped<IRequestHandler<GetBlogQuery,BlogDetailViewModel>, GetBlogQueryHandler>();

            services.AddScoped<ICommandHandler<AddBlogCommand>, AddBlogCommandHandler>();

            return services;
        }
    }
}
