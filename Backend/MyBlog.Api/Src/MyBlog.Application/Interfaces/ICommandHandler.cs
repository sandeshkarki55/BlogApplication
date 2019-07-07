using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface ICommandHandler<TCommand, TReturn> where TCommand : ICommand<TReturn>
    {
        Task<TReturn> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
