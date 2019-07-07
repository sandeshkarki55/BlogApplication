using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface IRequestHandler<TRequest, TReturn> where TRequest : IRequest<TReturn>
    {
        Task<TReturn> HandleAsync(TRequest request);
    }
}
