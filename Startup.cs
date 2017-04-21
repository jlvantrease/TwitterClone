using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
         services.AddMvc();
         //services.AddEntityFrameworkSqlServer();
        
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseMvc();
            app.UseStaticFiles();

            app.Run(context =>
            {
                return context.Response.WriteAsync("REST API");
            });
        }
    }
}
