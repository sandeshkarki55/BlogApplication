using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Models.Common;
using MyBlog.Application.Users.Commands.AddUser;
using MyBlog.Application.Users.Commands.DeleteUser;
using MyBlog.Application.Users.Queries.GetUser;
using MyBlog.Application.Users.Queries.GetUsers;
using MyBlog.Application.Users.Queries.GetUserSocialLinks;

using System.Net;
using System.Threading.Tasks;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets user by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Fetched user successfully.</response>
        /// <response code="404">User Doesn't Exist.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var user = await _mediator.Send(new GetUserQuery { Id = id });
            return Ok(new ResponseModel
            {
                Data = user,
                Message = "User fetched successfully.",
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Gets all the users.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Fetches All User Successfully.</response>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(new ResponseModel
            {
                Data = users,
                Message = "Users fetched successfully.",
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        /// <summary>
        /// Deletes User
        /// </summary>
        /// <param name="id">Id if a user</param>
        /// <returns></returns>
        /// <response code="204">Deleted user successfully.</response>
        /// <response code="404">User Doesn't Exist.</response>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var currentUser = 1;
            await _mediator.Send(new DeleteUserCommand { Id = id, DeletedBy = currentUser }, CancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Created user successfully.</response>
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUserCommand command)
        {
            var id = await _mediator.Send(command, CancellationToken);
            return CreatedAtAction(nameof(Get), new { id }, command);
        }

        /// <summary>
        /// Gets social links of User
        /// </summary>
        /// <param name="userName">Username of user</param>
        /// <returns></returns>
        /// <response code="200">Fetches social links of user.</response>
        /// <response code="404">User with username not found.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{userName}/SocialLinks")]
        public async Task<IActionResult> GetUserSocialLinks([FromRoute]string userName)
        {
            var userSocialLinks = await _mediator.Send(new GetUserSocialLinksQuery { UserName = userName });

            return Ok(new ResponseModel
            {
                Message = "User Social links fetched successfully.",
                Data = userSocialLinks,
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }
    }
}
