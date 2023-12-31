﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using dotnet_vite_react;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Components;
using dotnet_vite_react.Helper.Swagger;
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
                        if (value != null)
                        await context.Response.WriteAsync((string)value);
                    });
                    endpoints.MapControllers();
                   
                });
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("api is ready");
                });
            });
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });
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
            services.AddDbContext<Context>(optionsBuilder =>
            {
                string? connectionString = _builder.Configuration.GetConnectionString("LocalDb");
                if (connectionString != null)
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
            });
#if DEBUG
            services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<SwaggerPathPrefixInsertDocumentFilter>("api");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            }
            );
             
#endif
        }
    }
}