using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;

using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<UserListViewModel>> HandleAsync(GetUsersQuery request)
        {
            var users = await _myBlogDbContext.UserDetails.Include(x => x.Blogs).Select(x => new UserListViewModel
            {
                UserName = x.UserName,
                Adderss = x.Address,
                Email = x.Email,
                FullName = $"{x.FirstName} {x.LastName}",
                Id = x.Id,
                NoOfBlogs = x.Blogs.Count()
            }).ToListAsync();

            return users;
        }
    }
}
