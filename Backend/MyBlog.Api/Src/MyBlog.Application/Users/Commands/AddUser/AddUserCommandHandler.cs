using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Commands.AddUser
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand, int>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public AddUserCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }


        public async Task<int> HandleAsync(AddUserCommand command, CancellationToken cancellationToken)
        {
            UserDetail user = new UserDetail
            {
                UserName = command.UserName,
                Address = command.Address,
                Email = command.Email,
                FacebookUrl = command.FacebookUrl,
                FirstName = command.FacebookUrl,
                GithubUrl = command.GithubUrl,
                LastName = command.LastName,
                LinkedinUrl = command.LinkedinUrl,
                TwitterUrl = command.TwitterUrl
            };

            await _myBlogDbContext.UserDetails.AddAsync(user);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);

            //ToDoCall Identity server api

            return user.Id;
        }
    }
}
