using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MyBlog.Application.Accounts.Commands;
using MyBlog.Domain.Entities;
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
    }
}
