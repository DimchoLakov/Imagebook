using Imagebook.Data.Constants;
using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.PictureNameMaxLength);

            builder
                .HasOne(x => x.Album)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.AlbumId);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.LocationId);
        }
    }
}
