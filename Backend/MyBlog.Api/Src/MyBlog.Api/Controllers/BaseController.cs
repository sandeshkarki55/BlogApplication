using System.Threading;

using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Filters;

namespace MyBlog.API.Controllers
{
    [CustomExceptionFilter]
    public class BaseController : ControllerBase
    {
        protected CancellationToken CancellationToken { get; private set; }
        public BaseController()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken = cancellationTokenSource.Token;
        }
    }
}
