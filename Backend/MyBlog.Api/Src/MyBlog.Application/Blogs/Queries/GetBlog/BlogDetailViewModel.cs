using System;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class BlogDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string UserName { get; set; }
        public bool IsDraft { get; set; }
        public DateTime? PostedDate { get; set; }
        public string Tags { get; set; }
        public string CategoryName { get; set; }
    }
}
