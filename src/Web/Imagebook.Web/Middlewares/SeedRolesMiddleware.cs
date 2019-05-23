using System;
using System.Threading.Tasks;
using Imagebook.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Imagebook.Web.Middlewares
{
    public class SeedRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedRolesMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager)
        {
            var dbContext = serviceProvider.GetRequiredService<ImagebookDbContext>();

            if (!await dbContext.Roles.AnyAsync())
            {
                await this.SeedRoles(roleManager);
            }

            await this._next(context);
        }

        public async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}
