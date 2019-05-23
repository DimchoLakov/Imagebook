using System;
using Imagebook.Data.Constants;
using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.AlbumNameMaxLength);

            builder
                .Property(x => x.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.AlbumDescriptionMaxLength);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.LocationId);

            builder
                .HasMany(x => x.Comments)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId);
        }
    }
}
