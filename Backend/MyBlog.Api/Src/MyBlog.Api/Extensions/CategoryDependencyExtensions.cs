using Microsoft.Extensions.DependencyInjection;

using MyBlog.Application.Categories.Commands.AddCategory;
using MyBlog.Application.Categories.Commands.DeleteCategory;
using MyBlog.Application.Categories.Queries.GetCategories;
using MyBlog.Application.Categories.Queries.GetCategory;
using MyBlog.Application.Interfaces;

using System.Collections.Generic;

namespace MyBlog.API.Extensions
{
    public static class CategoryDependencyExtensions
    {
        public static IServiceCollection RegisterCategoryDependencies(this IServiceCollection services)
        {
            //Commands
            services.AddScoped<ICommandHandler<AddCategoryCommand, int>, AddCategoryCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCategoryCommand>, DeleteCategoryCommandHandler>();

            //Queries
            services.AddScoped<IRequestHandler<GetCategoriesQuery, List<CategoryListViewModel>>, GetCategoriesQueryHandler>();
            services.AddScoped<IRequestHandler<GetCategoryQuery, CategoryDetailViewModel>, GetCategoryQueryHandler>();
            
            return services;
        }
    }
}
