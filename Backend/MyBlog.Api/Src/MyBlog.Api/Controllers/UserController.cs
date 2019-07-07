using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Models.Common;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Users.Commands.DeleteUser;
using MyBlog.Application.Users.Queries.GetUser;
using MyBlog.Application.Users.Queries.GetUsers;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : BaseController
    {
        private readonly IRequestHandler<GetUserQuery, UserDetailViewModel> _getUserRequestHandler;
        private readonly IRequestHandler<GetUsersQuery, List<UserListViewModel>> _getUsersRequestHandler;
        private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommandHandler;

        public UserController(
            IRequestHandler<GetUserQuery, UserDetailViewModel> getUserRequestHandler,
            IRequestHandler<GetUsersQuery, List<UserListViewModel>> getUsersRequestHandler,
            ICommandHandler<DeleteUserCommand> deleteUserCommandHandler)
        {
            _getUserRequestHandler = getUserRequestHandler;
            _getUsersRequestHandler = getUsersRequestHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var user = await _getUserRequestHandler.HandleAsync(new GetUserQuery { Id = id });
            return Ok(new ResponseModel
            {
                Data = user,
                Message = "User fetched successfully.",
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _getUsersRequestHandler.HandleAsync(new GetUsersQuery());
            return Ok(new ResponseModel
            {
                Data = users,
                Message = "Users fetched successfully.",
                BlogStatusCode = (int)HttpStatusCode.OK
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var currentUser = 1;
            await _deleteUserCommandHandler.HandleAsync(new DeleteUserCommand { Id = id, DeletedBy = currentUser }, CancellationToken);
            return NoContent();
        }
    }
}
