using Microsoft.AspNetCore.Builder;

namespace Imagebook.Web.Middlewares
{
    public static class SeedDatabaseMiddlewareExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDatabaseMiddleware>();
        }
    }
}
