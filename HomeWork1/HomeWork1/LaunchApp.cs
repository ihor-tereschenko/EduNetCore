using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class LaunchApp
    {
        private IConfiguration _configuration { get; set; }

        public LaunchApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /*public void ConfigureServices(IServiceCollection services)
        {
        //This method is optional
        // Comment for devel branch
        }
        */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // private string MyGreeting;
                    // await context.Response.WriteAsync(_configuration["Greeting:AfterNoon"] + _configuration["UserTitle"]);
                    await context.Response.WriteAsync(_configuration["Logging:LogLevel:Microsoft.Hosting.Lifetime"]);
                });
            });
        }
    }
}
