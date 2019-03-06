using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mvc
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

            // here we register services that later one we can request from the framework
            // dependency inversion from SOLID is here
            // we will use that for deendency injection that 
            // enables great separation of concern.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // plugging in modules to handle cases
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // here we serve static files in 'wwwroot'
       
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // look controller with that name, and default is home and also index
            // here we configure "convention based routing" aka global routing
            // routing is the process/rules by which we decide which controller and which
            // action method will be instantiated and called to handle the current 
            // request
            app.UseMvc(routes =>
            {
                // mvc checks these "route conventions" one by one in order
                // looking for a match

                // if the url looks like: "GoToHome"
                // then delegate to some controller, Index action
                routes.MapRoute(
                    name: "homealias",
                    template: "GoToHome/{id?}",
                    defaults: new { Controller = "Home", Action = "Index" });
                routes.MapRoute(
                    name: "default",
                    // id? here is an optional route parameter
                    template: "{controller=Home}/{action=Index}/{id?}");
                // we can put a catch all at the very bottom
                // e.g. page not found
            });
            // c# lets us make obj of anonymous type or anonymous class
        }
    }
}
