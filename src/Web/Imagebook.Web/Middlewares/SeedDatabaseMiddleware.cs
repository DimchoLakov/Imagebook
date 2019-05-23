using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Imagebook.Data;
using Imagebook.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Imagebook.Web.Middlewares
{
    public class SeedDatabaseMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedDatabaseMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<ImagebookDbContext>();
            if (await dbContext.Albums.CountAsync() < 5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var album = new Album()
                    {
                        Name = $"Test Album ${i.ToString()}",
                        Description = $"Test Description ${i.ToString()}",
                        Location = new Location()
                        {
                            Name = $"Earth Number ${i.ToString()}"
                        }
                    };

                    await dbContext.Albums.AddAsync(album);
                }

                await dbContext.SaveChangesAsync();
            }

            await _next(context);
        }
    }
}
