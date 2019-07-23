using Microsoft.AspNetCore.Identity;

using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBlog.Application.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException()
        {
            Errors = new List<IdentityError>();
        }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
