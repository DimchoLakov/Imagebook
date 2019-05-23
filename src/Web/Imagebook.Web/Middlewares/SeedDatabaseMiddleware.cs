using System;
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
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await dbContext.Database.EnsureCreatedAsync();

            if (await dbContext.Users.FirstOrDefaultAsync() == null)
            {
                await userManager.CreateAsync(new User()
                {
                    Email = "test_user@gmail.com",
                    UserName = "test_username1",
                    FirstName = "Jon",
                    LastName = "Snow"
                }, "TestPass1");
            }

            if (await dbContext.Albums.CountAsync() < 5)
            {
                var user = await dbContext.Users.FirstOrDefaultAsync();

                for (int i = 0; i < 200; i++)
                {
                    var album = new Album()
                    {
                        Name = $"Test Album ${i.ToString()}",
                        Description = $"Test Description ${i.ToString()}",
                        Location = new Location()
                        {
                            Name = $"Earth Number ${i.ToString()}"
                        },
                        User = user
                    };

                    await dbContext.Albums.AddAsync(album);
                }

                await dbContext.SaveChangesAsync();
            }

            await _next(context);
        }
    }
}
