﻿using AutoMapper;
using Imagebook.Data;
using Imagebook.Data.Models;
using Imagebook.Data.Repositories;
using Imagebook.Data.Repositories.Contracts;
using Imagebook.Data.UnitOfWork;
using Imagebook.Data.UnitOfWork.Contracts;
using Imagebook.Services;
using Imagebook.Services.Contracts;
using Imagebook.Services.Mapping.Profiles;
using Imagebook.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Imagebook.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ImagebookDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies());

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ImagebookDbContext>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddDefaultTokenProviders();

            services.AddAuthentication();

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();

            // Services
            services.AddScoped<IAlbumsService, AlbumsService>();
            services.AddScoped<IPicturesService, PicturesService>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var mappingConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AlbumProfile());
                mc.AddProfile(new PictureProfile());
            });
            IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.SeedRoles();
            app.SeedDatabase();
            app.AddAdminRoleToFirstUser();

            app.UseStatusCodePagesWithRedirects("Home/Error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "show picture",
                    template: "pictures/{id}",
                    defaults: new { controller = "Pictures", action = "Show" }
                    );
            });
        }
    }
}
