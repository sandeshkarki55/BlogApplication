using MediatR;

namespace MyBlog.Application.Accounts.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
