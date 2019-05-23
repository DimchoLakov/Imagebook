using Microsoft.AspNetCore.Builder;

namespace Imagebook.Web.Middlewares
{
    public static class SeedRolesMiddlewareExtensions
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedRolesMiddleware>();
        }
    }
}
