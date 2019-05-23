using Microsoft.AspNetCore.Builder;

namespace Imagebook.Web.Middlewares
{
    public static class AddAdminRoleToFirstUserMiddlewareExtensions
    {
        public static IApplicationBuilder AddAdminRoleToFirstUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddAdminRoleToFirstUserMiddleware>();
        }
    }
}
