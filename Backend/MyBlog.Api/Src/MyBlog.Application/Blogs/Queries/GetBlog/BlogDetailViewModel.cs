using System;

namespace MyBlog.Application.Blogs.Queries.GetBlog
{
    public class BlogDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostedDate { get; set; }
        public string Tags { get; set; }
        public string CategoryName { get; set; }
    }
}
