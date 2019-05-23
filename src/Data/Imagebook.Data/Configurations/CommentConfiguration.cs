using Imagebook.Data.Constants;
using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Heading)
                .IsUnicode(true);

            builder
                .Property(x => x.Content)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.CommentContentMaxLength);

            builder
                .HasOne(x => x.Picture)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PictureId);
        }
    }
}
