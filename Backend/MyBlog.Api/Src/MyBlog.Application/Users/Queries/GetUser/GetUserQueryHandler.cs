using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailViewModel>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public GetUserQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<UserDetailViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _myBlogDbContext.UserDetails.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(UserDetail), request.Id);
            }

            return new UserDetailViewModel
            {
                UserName = user.UserName,
                Address = user.Address,
                FacebookUrl = user.FacebookUrl,
                FullName = user.Name.FullName,
                GithubUrl = user.GithubUrl,
                LinkedinUrl = user.LinkedinUrl,
                TwitterUrl = user.TwitterUrl
            };
        }
    }
}
