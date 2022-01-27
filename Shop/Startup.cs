using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Premium.Data.interfaces;
using Premium.Data.mocks;
using Microsoft.Extensions.Configuration;
using Premium.Data;
using Premium.Data.Repository;
using Premium.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Premium
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup (IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IALLCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => PremiumCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCoreAdmin();
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Monthly", new CacheProfile { Duration = 60 * 60 * 24 * 7 * 4 });
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDBContent>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller = Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
            });



            using (var scope = app.ApplicationServices.CreateScope())
            {
              AppDBContent  content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

            
        }
    }
}
