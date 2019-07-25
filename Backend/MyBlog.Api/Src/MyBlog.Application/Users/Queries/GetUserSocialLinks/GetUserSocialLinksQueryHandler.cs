using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Queries.GetUserSocialLinks
{
    public class GetUserSocialLinksQueryHandler : IRequestHandler<GetUserSocialLinksQuery, UserSocialLinksViewModel>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserSocialLinksQueryHandler(IMyBlogDbContext myBlogDbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _myBlogDbContext = myBlogDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserSocialLinksViewModel> Handle(GetUserSocialLinksQuery request, CancellationToken cancellationToken)
        {
            var userDetailId = _httpContextAccessor.HttpContext.User.FindFirstValue("UserDetailId");
            var userDetails = await _myBlogDbContext.UserDetails.FirstOrDefaultAsync(x => x.Id == int.Parse(userDetailId) && !x.IsDeleted);

            if (userDetails == null)
            {
                throw new NotFoundException(nameof(UserDetail), userDetailId);
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
