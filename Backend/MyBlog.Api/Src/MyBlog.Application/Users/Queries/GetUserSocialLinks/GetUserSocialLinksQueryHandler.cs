using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Queries.GetUserSocialLinks
{
    public class GetUserSocialLinksQueryHandler : IRequestHandler<GetUserSocialLinksQuery, UserSocialLinksViewModel>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public GetUserSocialLinksQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<UserSocialLinksViewModel> Handle(GetUserSocialLinksQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _myBlogDbContext.UserDetails.FirstOrDefaultAsync(x => x.UserName == request.UserName && !x.IsDeleted);

            if (userDetails == null)
            {
                throw new NotFoundException(nameof(UserDetail), request.UserName);
            }

            return new UserSocialLinksViewModel
            {
                FacebookUrl = userDetails.FacebookUrl,
                GithubUrl = userDetails.GithubUrl,
                LinkedinUrl = userDetails.LinkedinUrl,
                TwitterUrl = userDetails.TwitterUrl
            };
        }
    }
}
