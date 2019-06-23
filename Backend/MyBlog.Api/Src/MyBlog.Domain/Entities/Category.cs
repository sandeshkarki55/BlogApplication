using System.Collections.Generic;

namespace MyBlog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
        }

        public string Name { get; set; }
        public ICollection<Blog> Blogs { get; private set; }
    }
}
