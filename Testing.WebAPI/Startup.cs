using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Testing.WebAPI.Data;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Testing.WebAPI
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("sqlDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGet("/neville", async context => {
                await context.Response.WriteAsync("This is neville");
            });

            app.UseMvc();
        }
    }

    public static class Extender
    {
        public static IApplicationBuilder UseGet(this IApplicationBuilder app, 
                                                    PathString path, Func<HttpContext, Task> middleware)
            => app.Use(async (context, next) => {

                if (context.Request.Path == path && context.Request.Method == "GET")
                    await middleware(context);
                else await next();
            });

        public static IApplicationBuilder UseGet(this IApplicationBuilder app,
                                                    PathString path, Func<HttpContext, Func<Task>, Task> middleware)
            => app.Use(async (context, next) => {

                if (context.Request.Path == path && context.Request.Method == "GET")
                    await middleware(context, next);
                else await next();
            });
    }

}


