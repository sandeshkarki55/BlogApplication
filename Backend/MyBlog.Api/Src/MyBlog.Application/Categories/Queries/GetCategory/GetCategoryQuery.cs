using MediatR;

namespace MyBlog.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDetailViewModel>
    {
        public int Id { get; set; }
    }
}
