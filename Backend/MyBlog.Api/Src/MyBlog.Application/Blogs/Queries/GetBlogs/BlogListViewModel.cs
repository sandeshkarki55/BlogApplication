using System;

namespace MyBlog.Application.Blogs.Queries.GetBlogs
{
    public class BlogListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostedDate { get; set; }
        public string Tags { get; set; }
        public string CategoryName { get; set; }
    }
}
