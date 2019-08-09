using MediatR;

using MyBlog.Application.Categories.Models;

using System.Collections.Generic;

namespace MyBlog.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryListViewModel>>
    {

    }
}
