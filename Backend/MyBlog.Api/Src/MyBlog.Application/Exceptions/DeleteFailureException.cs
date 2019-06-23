using System;

namespace MyBlog.Application.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string typeName, object key, string message)
            : base($"Can't Delete {typeName} ({key}). {message}")
        {
        }
    }
}
