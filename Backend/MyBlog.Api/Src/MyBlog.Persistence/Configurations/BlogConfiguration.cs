
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MyBlog.Domain.Entities;

namespace MyBlog.Persistence.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.CategoryId)
                .HasColumnName("CategoryID")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasMaxLength(50);

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(350)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
