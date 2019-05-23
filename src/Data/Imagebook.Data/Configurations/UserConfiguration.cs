using System;
using Imagebook.Data.Constants;
using Imagebook.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imagebook.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.UserFirstNameMaxLength);

            builder
                .Property(x => x.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(ModelsConstants.UserLastNameMaxLength);

            builder
                .Property(x => x.CreatedOn)
                .IsRequired(true)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .Property(x => x.UserName)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(ModelsConstants.UserUserNameMaxLength);

            builder
                .HasOne(x => x.Picture)
                .WithOne(x => x.User)
                .HasForeignKey<Picture>(x => x.UserId);
        }
    }
}
