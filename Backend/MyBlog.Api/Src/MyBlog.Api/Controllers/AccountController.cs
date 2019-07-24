using MediatR;

using Microsoft.AspNetCore.Mvc;

using MyBlog.Application.Accounts.Commands.Login;
using MyBlog.Application.Accounts.Commands.RegisterUser;

using System.Threading.Tasks;

namespace MyBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
