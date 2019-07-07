using MyBlog.Application.Interfaces;

namespace MyBlog.Application.Users.Queries.GetUser
{
    public class GetUserQuery:IRequest<UserDetailViewModel>
    {
        public int Id { get; set; }
    }
}
