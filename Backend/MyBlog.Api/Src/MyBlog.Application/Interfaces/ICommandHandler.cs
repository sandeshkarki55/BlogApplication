using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface ICommandHandler<TCommand, TReturn> where TCommand : ICommand<TReturn>
    {
        Task<TReturn> Handle(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}
