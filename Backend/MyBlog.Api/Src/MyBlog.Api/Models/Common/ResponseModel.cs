namespace MyBlog.API.Models.Common
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public int BlogStatusCode { get; set; }
        public object Data { get; set; }
    }
}
