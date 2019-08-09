using MediatR;

using MyBlog.Application.Categories.Models;
using MyBlog.Common.DataTable;

namespace MyBlog.Application.Categories.Queries.GetCategoriesDataTable
{
    public class GetCategoriesDataTableQuery : DTParameters, IRequest<DTResult<CategoryListViewModel>>
    {
    }
}
