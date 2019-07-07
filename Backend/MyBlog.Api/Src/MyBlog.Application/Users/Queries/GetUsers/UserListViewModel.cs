namespace MyBlog.Application.Users.Queries.GetUsers
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Adderss { get; set; }
        public string Email { get; set; }
        public int NoOfBlogs { get; set; }
    }
}
