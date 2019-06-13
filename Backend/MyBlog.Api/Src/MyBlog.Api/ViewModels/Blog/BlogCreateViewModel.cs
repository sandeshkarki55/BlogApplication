using System.ComponentModel.DataAnnotations;

namespace MyBlog.Api.ViewModels.Blog
{
    public class BlogCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
