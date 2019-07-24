using MediatR;

using Microsoft.AspNetCore.Identity;

using MyBlog.Application.Exceptions;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Accounts.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new IdentityException
                {
                    Errors = result.Errors
                };
            }

            return Unit.Value;
        }
    }
}
