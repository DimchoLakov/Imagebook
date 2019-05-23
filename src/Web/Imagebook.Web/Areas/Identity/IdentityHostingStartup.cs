using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Imagebook.Web.Areas.Identity.IdentityHostingStartup))]
namespace Imagebook.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}