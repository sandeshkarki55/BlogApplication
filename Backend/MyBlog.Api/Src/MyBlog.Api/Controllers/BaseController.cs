using Microsoft.AspNetCore.Mvc;

using MyBlog.API.Filters;

using System.Threading;

namespace MyBlog.API.Controllers
{
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
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
