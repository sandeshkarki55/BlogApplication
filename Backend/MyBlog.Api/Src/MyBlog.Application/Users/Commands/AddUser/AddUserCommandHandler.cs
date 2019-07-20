﻿using MediatR;

using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public AddUserCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            UserDetail user = new UserDetail
            {
                UserName = request.UserName,
                Address = request.Address,
                Email = request.Email,
                FacebookUrl = request.FacebookUrl,
                FirstName = request.FacebookUrl,
                GithubUrl = request.GithubUrl,
                LastName = request.LastName,
                LinkedinUrl = request.LinkedinUrl,
                TwitterUrl = request.TwitterUrl
            };

            await _myBlogDbContext.UserDetails.AddAsync(user);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
