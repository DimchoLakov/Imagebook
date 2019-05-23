using System;
using System.Threading.Tasks;
using Imagebook.Data;
using Imagebook.Data.Models;
using Imagebook.Web.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Imagebook.Web.Middlewares
{
    public class AddAdminRoleToFirstUserMiddleware
    {
        private readonly RequestDelegate _next;

        public AddAdminRoleToFirstUserMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ImagebookDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            if (!await dbContext.UserRoles.AnyAsync())
            {
                if (await dbContext.Users.CountAsync() == 1)
                {
                    var user = await dbContext.Users.FirstOrDefaultAsync();
                    await userManager.AddToRoleAsync(user, UserRoleConstants.Admin);
                }
            }

            await this._next(httpContext);
        }
    }
}
