using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserListViewModel>>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public GetUsersQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<List<UserListViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _myBlogDbContext.UserDetails.Select(x => new UserListViewModel
            {
                UserName = x.UserName,
                Adderss = x.Address,
                FullName = x.Name.FullName,
                Id = x.Id,
                //NoOfBlogs = x.User.Blogs.Count()
            }).ToListAsync();

            return users;
        }
    }
}
