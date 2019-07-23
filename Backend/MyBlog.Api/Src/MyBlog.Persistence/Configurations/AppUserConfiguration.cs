using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.UserDetail)
                .WithOne(x => x.User)
                .HasForeignKey<UserDetail>(x => x.UserName)
                .HasPrincipalKey<AppUser>(x => x.UserName);
        }
    }
}
