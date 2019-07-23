using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(50);

            builder.OwnsOne(x => x.Name, y =>
            {
                y.Property(x => x.FirstName).HasMaxLength(50)
                .HasColumnName("FirstName");

                y.Property(x => x.LastName).HasMaxLength(50)
                .HasColumnName("LastName");

                y.Ignore(x => x.FullName);
            });

            builder.HasMany(x => x.Blogs)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.UserDetailId);
        }
    }
}
