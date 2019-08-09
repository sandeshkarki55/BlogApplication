using System;
using System.Linq.Expressions;

namespace MyBlog.Application.Categories.Models
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfBlogs { get; set; }
        public int SN { get; set; }
    }
}
