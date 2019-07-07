using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasMany(x => x.Blogs)
                 .WithOne(x => x.Author)
                 .HasForeignKey(x => x.UserName)
                 .HasPrincipalKey(x => x.UserName);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(75).IsRequired();

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(50);
        }
    }
}
