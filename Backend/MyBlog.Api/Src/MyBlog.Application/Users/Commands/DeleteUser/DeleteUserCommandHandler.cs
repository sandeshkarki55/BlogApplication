using MyBlog.Application.Interfaces;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IMyBlogDbContext _myBlogDbContext;

        public DeleteUserCommandHandler(IMyBlogDbContext myBlogDbContext)
        {
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _myBlogDbContext.UserDetails.FindAsync(command.Id);

            user.IsDeleted = true;
            user.DeleteDateTime = DateTime.UtcNow;
            user.DeletedBy = command.DeletedBy;

            _myBlogDbContext.UserDetails.Update(user);
            await _myBlogDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
