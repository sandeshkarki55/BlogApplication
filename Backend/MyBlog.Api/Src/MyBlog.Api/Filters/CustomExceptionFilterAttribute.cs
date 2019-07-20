using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using MyBlog.API.Models.Common;
using MyBlog.Application.Exceptions;

using System;
using System.Net;

namespace MyBlog.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new ResponseModel
            {
                Message = context.Exception.Message,
                BlogStatusCode = (int)statusCode
            });

            _logger.LogError(context.Exception, "Exception in request.");
        }
    }
}
