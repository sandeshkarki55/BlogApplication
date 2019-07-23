using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public UserDetail UserDetail { get; set; }
    }
}
