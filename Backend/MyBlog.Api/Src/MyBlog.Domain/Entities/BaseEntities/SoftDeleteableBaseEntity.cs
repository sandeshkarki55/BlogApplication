using System;

namespace MyBlog.Domain.Entities.BaseEntities
{
    public class SoftDeleteableBaseEntity : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    }
}
