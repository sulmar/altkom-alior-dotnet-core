using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace Altkom.DotnetCore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            app.Use(async (context, next) =>
            {
                if (context.Request.Headers.TryGetValue("Authorization", out StringValues values))
                {
                    // TODO: 

                    await next.Invoke();
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            });
            */

            //app.Use(async (context, next) =>
            //{
            //    Trace.WriteLine($"request: {context.Request.Method} {context.Request.Path}");

            //    await next.Invoke();

            //    Trace.WriteLine($"Response: {context.Response.StatusCode}");
            //});

            //  app.UseMiddleware<LoggerMiddleware>();

            app.UseLogger();

            app.UseMiddleware<RequestAcceptMiddleware>();


            // GET /dashboard

            app.Map("/dashboard", DashboardHandler);

            // GET /sensors
            // GET /sensors/temp
            // GET /sensors/humidity
            
            app.Map("/sensors", node =>
            {
                node.Map("/temp", TempHandler);
                node.Map("/humidity", HumidityHandler);
                node.Map(string.Empty, SensorsHandler);
            });

            app.Use(async (context, next) =>
            {
                Trace.WriteLine("send email");

                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void SensorsHandler(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("all sensors"));
        }

        private void HumidityHandler(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("95%"));
        }

        private void TempHandler(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Temp 23C"));
        }

        private void DashboardHandler(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Dashboard"));
        }
    }
}
