using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Data;
using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cinema
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CinemaContext>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
            services.AddTransient<UploadFileService>();
            services.AddIdentity<User, IdentityRole>(
                    options =>
                    {
                        options.Password.RequireDigit = false; 
                        options.Password.RequiredLength = 5; 
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false; 
                        options.Password.RequiredUniqueChars = 1; 
                        options.Password.RequireNonAlphanumeric = false; 
                    })
                .AddEntityFrameworkStores<CinemaContext>();;
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Films}/{action=Index}/{id?}");
            });
        }
    }
}