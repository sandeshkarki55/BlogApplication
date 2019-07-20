using MediatR;

namespace MyBlog.Application.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LinkedinUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string GithubUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
