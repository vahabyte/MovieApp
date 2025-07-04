using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Data;
namespace MovieApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            services.AddControllersWithViews();
            
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints => {

                endpoints.MapControllerRoute(
                    
                    name:"default",
                    pattern:"{Controller=Home}/{action=Index}/{id?}"

                    
                    );
            
            
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(

            //        name: "Home",
            //        pattern: "",
            //        defaults: new { controller = "Home", action = "Index" }

            //        );
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(

            //        name: "Home",
            //        pattern: "hakkimizda",
            //        defaults: new { controller = "Home", action = "about" }

            //        );
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(

            //        name:"movieList",
            //        pattern:"movies/list",
            //        defaults: new { controller = "Movies", action = "List" }

            //        );    
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(

            //        name: "movieList",
            //        pattern: "movies/details",
            //        defaults: new { controller = "Movies", action = "Details" }

            //        );
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(

            //        name: "movieDetails",
            //        pattern: "movies/details",
            //        defaults: new { controller = "Movies", action = "Details" }

            //        );
            //});






        }
    }
}
