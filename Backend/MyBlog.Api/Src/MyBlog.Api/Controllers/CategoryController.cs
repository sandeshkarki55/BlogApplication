using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MyBlog.Application.Categories.Commands.AddCategory;
using MyBlog.Application.Categories.Commands.DeleteCategory;
using MyBlog.Application.Categories.Queries.GetCategories;
using MyBlog.Application.Categories.Queries.GetCategory;
using MyBlog.Application.Interfaces;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICommandHandler<AddCategoryCommand, int> _addCategoryCommandHandler;
        private readonly ICommandHandler<DeleteCategoryCommand> _deleteCategoryCommandHandler;
        private readonly IRequestHandler<GetCategoryQuery, CategoryDetailViewModel> _getCategoryRequestHandler;
        private readonly IRequestHandler<GetCategoriesQuery, List<CategoryListViewModel>> _getCategoriesRequestHandler;

        public CategoryController(ICommandHandler<AddCategoryCommand, int> addCategoryCommandHandler,
            ICommandHandler<DeleteCategoryCommand> deleteCategoryCommandHandler,
            IRequestHandler<GetCategoryQuery, CategoryDetailViewModel> getCategoryRequestHandler,
            IRequestHandler<GetCategoriesQuery, List<CategoryListViewModel>> getCategoriesRequestHandler)
        {
            _addCategoryCommandHandler = addCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
            _getCategoryRequestHandler = getCategoryRequestHandler;
            _getCategoriesRequestHandler = getCategoriesRequestHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]AddCategoryCommand command)
        {
            int categoryId = await _addCategoryCommandHandler.Handle(command, CancellationToken);
            return Created($"/api/category/{categoryId}", categoryId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CategoryListViewModel> categories = await _getCategoriesRequestHandler.Handle(new GetCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            CategoryDetailViewModel category = await _getCategoryRequestHandler.Handle(new GetCategoryQuery { Id = id });
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _deleteCategoryCommandHandler.Handle(new DeleteCategoryCommand { Id = id }, CancellationToken);
            return NoContent();
        }
    }
}
