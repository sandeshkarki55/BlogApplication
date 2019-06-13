using MyBlog.Common.Enums;

namespace MyBlog.Common.Models
{
    public class ResponseModel
    {
        public MyBlogStatusCode BlogStatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
