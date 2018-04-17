namespace BestBulgarianMovies.Web
{
    using AutoMapper;
    using BestBulgarianMovies.Data;
    using BestBulgarianMovies.Data.Models;
    using BestBulgarianMovies.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BestBulgarianMoviesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), p=> p.UseRowNumberForPaging()));

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<BestBulgarianMoviesDbContext>()
                .AddDefaultTokenProviders();

            //Add reflection extension for DI in project
            services.AddDomainServices();

            //Add AutoMapper in project
            services.AddAutoMapper();

            //Add Facebook Authentication
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "203135413586790";
                facebookOptions.AppSecret = "fe219b3e2bebffecfe1a7659382a47d8";
            });

            //Add Google Authentication
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "743114518353-b0ab4ml26kclmdj8hiq5lla8kk5gq1at.apps.googleusercontent.com";
                googleOptions.ClientSecret = "r3j_zXV9FZ2kSPJCsjOnSYb8";
            });

            //Lower Case URL
            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                //Preventing Cross-Site Request Forgery (CSRF)
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Auto Migration with Roles
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
