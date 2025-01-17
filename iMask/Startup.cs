using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMask.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iMask
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
            services.AddMemoryCache();

            services.AddSingleton<LineBotConfig, LineBotConfig>((s) => new LineBotConfig
            {
                channelSecret = Configuration["00993f5bfd2a792015b00ac06ebba568"],
                accessToken = Configuration["ocm6ZJTBy/RPknWUE60fkv55Qov9RNSY8EuBXei5rjuV3ts9TkfEUA2I/5wGGMUrjbaeAWMedrnatD3WE1z9oy4ZzMU/z2mbYUasaQMtUD1bPjc2G0E7kkHCEO9+RbHbdkWNMxsbYDPxpBcvnhQoWgdB04t89/1O/w1cDnyilFU="]
            });

            services.AddScoped<CacheService, CacheService>();

            services.AddHttpContextAccessor();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
