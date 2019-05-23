using Imagebook.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Imagebook.Data
{
    public class ImagebookDbContextFactory : IDesignTimeDbContextFactory<ImagebookDbContext>
    {
        public ImagebookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImagebookDbContext>();
            optionsBuilder
                .UseSqlServer(ConfigurationConstants.ConnectionString)
                .UseLazyLoadingProxies();

            return new ImagebookDbContext(optionsBuilder.Options);
        }
    }
}
