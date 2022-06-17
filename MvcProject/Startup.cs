using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcProject.Data;
using MvcProject.Reposetorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject
{
    public class Startup
    {
        private IConfiguration _iconfiguration;
        public Startup(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            string connectionString = _iconfiguration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddControllersWithViews();

        }


        public void Configure(IApplicationBuilder app, ShopContext ctx, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=ShowHomePage}/{id?}");
            });
        }
    }
}
