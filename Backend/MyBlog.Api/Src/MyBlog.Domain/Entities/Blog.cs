using System;

namespace MyBlog.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string UserId { get; set; }
        public bool IsDraft { get; set; }
        public DateTime? PostedDate { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
