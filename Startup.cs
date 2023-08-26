using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
namespace dotnet_vite_vuejs
{
    public class Startup
    {
        private WebApplicationBuilder _builder;
        public Startup(WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            this._builder = builder;
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.Map("/api", app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Test}/{action=Index}/{id?}");
                    
                    endpoints.MapGet("/number/{value}", async context =>
                    {
                        var value = context.Request.RouteValues["value"];
                        value = null;
                        await context.Response.WriteAsync(value?.ToString());
                    });
                });
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("api is ready");
                });
            });
#if DEBUG
#elif RELEASE
            app.Map("", app =>
            {
                StaticFileOptions ClientApp = new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                    Path.Combine(
                        this._builder.Environment.ContentRootPath,
                        "ClientApp/dist"
                        )
                    )
                };
                app.UseStaticFiles(ClientApp);
                app.UseSpa(spa =>
                {
                    spa.Options.DefaultPageStaticFileOptions = ClientApp;

                });
            });
#endif
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}