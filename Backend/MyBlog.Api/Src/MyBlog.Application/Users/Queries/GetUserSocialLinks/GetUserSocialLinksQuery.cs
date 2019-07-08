using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Users.Queries.GetUserSocialLinks
{
    public class GetUserSocialLinksQuery : IRequest<UserSocialLinksViewModel>
    {
        public string UserName { get; set; }
    }
}
