using System;

namespace MyBlog.Application.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Credentials are not valid for the user.")
        {
        }
    }
}
