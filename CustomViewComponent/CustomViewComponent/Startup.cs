using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CustomViewComponent.Models;

namespace CustomViewComponent
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddSingleton<IRepository, MemoryRepository>();
	        services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			app.UseStatusCodePages();
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
    }
}
