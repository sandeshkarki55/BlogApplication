using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserListViewModel>>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        private static readonly Expression<Func<UserDetail, UserListViewModel>> _projection = x => new UserListViewModel
        {
            Id = x.Id,
            UserName = x.UserName,
            Adderss = x.Address,
            FullName = x.Name.FullName,
            NoOfBlogs = x.Blogs.Count()
        };

        public GetUsersQueryHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<List<UserListViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _myBlogDbContext.UserDetails.Select(_projection).ToListAsync();

            return users;
        }
    }
}
