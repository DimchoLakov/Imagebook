using Imagebook.Data.Configurations;
using Imagebook.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imagebook.Data
{
    public class ImagebookDbContext : IdentityDbContext<User>
    {
        public ImagebookDbContext(DbContextOptions<ImagebookDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagAlbum> TagAlbums { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AlbumConfiguration())
                .ApplyConfiguration(new CommentConfiguration())
                .ApplyConfiguration(new LocationConfiguration())
                .ApplyConfiguration(new PictureConfiguration())
                .ApplyConfiguration(new TagAlbumConfiguration())
                .ApplyConfiguration(new TagConfiguration())
                .ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
