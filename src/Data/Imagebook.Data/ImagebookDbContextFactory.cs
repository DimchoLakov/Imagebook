using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Imagebook.Data
{
    public class ImagebookDbContextFactory : IDesignTimeDbContextFactory<ImagebookDbContext>
    {
        public ImagebookDbContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var goThreeDirsBack = "../../../";
            var webDirectory = "Web/Imagebook.Web/";
            var fullPath = Path.GetFullPath(currentDirectory + goThreeDirsBack + webDirectory);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(fullPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ImagebookDbContext>();
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

            return new ImagebookDbContext(optionsBuilder.Options);
        }
    }
}
