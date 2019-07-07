using MyBlog.Domain.Entities.BaseEntities;

using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class UserDetail : SoftDeleteableBaseEntity
    {
        public UserDetail()
        {
            Blogs = new HashSet<Blog>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LinkedinUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string GithubUrl { get; set; }
        public string TwitterUrl { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
