using Imagebook.Data.Constants;
using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.LocationNameMaxLength);
        }
    }
}
