using MediatR;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;
using MyBlog.Domain.ValueObjects;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public AddUserCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            UserDetail user = new UserDetail
            {
                UserName = request.UserName,
                Address = request.Address,
                FacebookUrl = request.FacebookUrl,
                GithubUrl = request.GithubUrl,
                LinkedinUrl = request.LinkedinUrl,
                TwitterUrl = request.TwitterUrl,
                Name = new PersonName(request.FirstName, request.LastName)
            };

            await _myBlogDbContext.UserDetails.AddAsync(user);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
