using MediatR;
using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
        public int DeletedBy { get; set; }
    }
}
