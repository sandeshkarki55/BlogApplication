using MediatR;

using System.Collections.Generic;

namespace MyBlog.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserListViewModel>>
    {

    }
}
