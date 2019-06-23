using System;

namespace MyBlog.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object key) : base($"Entity: {entityName}. ({key}) not found.")
        {
        }
    }
}
