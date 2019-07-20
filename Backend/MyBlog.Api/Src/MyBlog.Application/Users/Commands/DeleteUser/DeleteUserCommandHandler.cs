using MediatR;

using Microsoft.EntityFrameworkCore;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public DeleteUserCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _myBlogDbContext.UserDetails.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id);

            if (user == null)
            {
                throw new NotFoundException(nameof(UserDetail), request.Id);
            }

            user.IsDeleted = true;
            user.DeleteDateTime = DateTime.UtcNow;
            user.DeletedBy = request.DeletedBy;

            _myBlogDbContext.UserDetails.Update(user);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
