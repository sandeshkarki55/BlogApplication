using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Models.Common;
using MyBlog.Application.Categories.Commands.AddCategory;
using MyBlog.Application.Categories.Commands.DeleteCategory;
using MyBlog.Application.Categories.Queries.GetCategories;
using MyBlog.Application.Categories.Queries.GetCategory;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Id of created category</returns>
        /// <response code="201">Returns the newly created category id</response>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateCategory([FromBody]AddCategoryCommand command)
        {
            int id = await _mediator.Send(command, CancellationToken);
            return CreatedAtAction(nameof(Get), new { id }, command);
        }

        /// <summary>
        /// Gets all Categories.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Return all categories from database.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            List<CategoryListViewModel> categories = await _mediator.Send(new GetCategoriesQuery());
            return Ok(new ResponseModel
            {
                Message = "All categories fetched successfully.",
                Data = categories,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Gets category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="404">If the category with given id is not found.</response>
        /// <response code="200">Return category specific to given id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            CategoryDetailViewModel category = await _mediator.Send(new GetCategoryQuery { Id = id });

            return Ok(new ResponseModel
            {
                Message = "category fetched successfully.",
                Data = category,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Delete Category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Category deleted successfully.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id }, CancellationToken);
            return NoContent();
        }
    }
}
