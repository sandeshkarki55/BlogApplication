using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Categories.Models;
using MyBlog.Application.Interfaces;
using MyBlog.Common.DataTable;
using MyBlog.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Categories.Queries.GetCategoriesDataTable
{
    public class GetCategoriesDataTableQueryHandler : IRequestHandler<GetCategoriesDataTableQuery, DTResult<CategoryListViewModel>>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        private static Expression<Func<Category, CategoryListViewModel>> _projection = x => new CategoryListViewModel
        {
            Id = x.Id,
            Name = x.Name,
            NoOfBlogs = x.Blogs.Count()
        };

        public GetCategoriesDataTableQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<DTResult<CategoryListViewModel>> Handle(GetCategoriesDataTableQuery request, CancellationToken cancellationToken)
        {
            var orderInfo = request.Order[0];

            Expression<Func<Category, bool>> search = x => x.Name.ToLower().Contains(request.Search.Value.ToLower());

            var categoriesCount = await _myBlogDbContext.Categories.CountAsync();

            var categories = await _myBlogDbContext.Categories
                                        .Where(search)
                                        .Skip(request.Start)
                                        .Take(request.Length)
                                        .Select(_projection)
                                        .ToListAsync();

            categories = OrderData(orderInfo.Column, orderInfo.Dir, categories).ToList();

            var count = request.Start + 1;
            categories.ForEach(x => x.SN = count++);

            return new DTResult<CategoryListViewModel>
            {
                Data = categories,
                Draw = request.Draw,
                RecordsFiltered = categoriesCount,
                RecordsTotal = categoriesCount
            };
        }

        private IEnumerable<CategoryListViewModel> OrderData(int column, DtOrderDir orderDirection, List<CategoryListViewModel> categories)
        {
            switch (column)
            {
                case 1:
                    return orderDirection == DtOrderDir.Asc ? categories.OrderBy(x => x.Name) : categories.OrderByDescending(x => x.Name);
                default:
                    return orderDirection == DtOrderDir.Asc ? categories.OrderBy(x => x.Name) : categories.OrderByDescending(x => x.Name);

            }
        }
    }
}
