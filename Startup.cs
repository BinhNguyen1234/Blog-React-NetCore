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
            var b = env;
            app.UseRouting();
            app.Map("/api", app =>
            {
                app.UseRouting();
                app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Test}/{action=Index}/{id?}");
                endpoints.MapGet("", async context =>
                {
                    await context.Response.WriteAsync("rootAPi");
                });
                endpoints.MapGet("/12", async context =>
                {
                    await context.Response.WriteAsync("12");
                });
            });
            });
#if DEBUG
#elif RELEASE
            app.UseStaticFiles();
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