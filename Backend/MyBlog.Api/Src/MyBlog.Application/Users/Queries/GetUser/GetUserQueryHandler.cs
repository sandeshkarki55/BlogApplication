using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

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

        public async Task<UserDetailViewModel> HandleAsync(GetUserQuery request)
        {
            var user = await _myBlogDbContext.UserDetails.FindAsync(request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(UserDetail), request.Id);
            }

            return new UserDetailViewModel
            {
                UserName = user.UserName,
                Address = user.Address,
                Email = user.Email,
                FacebookUrl = user.FacebookUrl,
                FirstName = user.FirstName,
                GithubUrl = user.GithubUrl,
                LastName = user.LastName,
                LinkedinUrl = user.LinkedinUrl,
                TwitterUrl = user.TwitterUrl
            };
        }
    }
}
