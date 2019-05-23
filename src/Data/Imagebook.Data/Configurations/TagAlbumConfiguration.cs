using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class TagAlbumConfiguration : IEntityTypeConfiguration<TagAlbum>
    {
        public void Configure(EntityTypeBuilder<TagAlbum> builder)
        {
            builder
                .HasKey(x => new { x.AlbumId, x.TagId });

            builder
                .HasOne(x => x.Album)
                .WithMany(x => x.AlbumTags)
                .HasForeignKey(x => x.AlbumId);

            builder
                .HasOne(x => x.Tag)
                .WithMany(x => x.TagAlbums)
                .HasForeignKey(x => x.TagId);
        }
    }
}
