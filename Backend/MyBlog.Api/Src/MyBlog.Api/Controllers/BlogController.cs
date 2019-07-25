using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Models.Common;
using MyBlog.Application.Blogs.Commands.AddBlog;
using MyBlog.Application.Blogs.Queries.GetBlog;
using MyBlog.Application.Blogs.Queries.GetBlogs;
using MyBlog.Application.Blogs.Queries.GetRecentBlogs;

using System.Net;
using System.Threading.Tasks;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BlogController : BaseController
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Saves the blog
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="204">When blog is saved successfully.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(204)]
        public async Task<IActionResult> SaveBlog(AddBlogCommand command)
        {
            await _mediator.Send(command, CancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Gets all blogs
        /// </summary>
        /// <returns>List of all posted blogs</returns>
        /// <response code="200">Fetches all blogs successfully.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _mediator.Send(new GetBlogsQuery());
            return Ok(new ResponseModel
            {
                Message = "Blogs fetched successfully.",
                Data = blogs,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Gets recent blogs.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Gets latest blogs.</response>
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("Recent")]
        public async Task<IActionResult> GetRecent()
        {
            var recentBlogs = await _mediator.Send(new GetRecentBlogsQuery());

            return Ok(new ResponseModel
            {
                Message = "Recent Blogs fetched successfully.",
                Data = recentBlogs,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Gets blog by its id.
        /// </summary>
        /// <param name="id">Id of a blog</param>
        /// <returns>Blog detail</returns>
        /// <response code="200">When blog with id exists</response>
        /// <response code="404">When blog is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _mediator.Send(new GetBlogQuery { Id = id });
            return Ok(new ResponseModel
            {
                Message = $"Blog with id {id} fetched successfully.",
                Data = blog,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }
    }
}
