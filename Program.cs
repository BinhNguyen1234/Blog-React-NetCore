using dotnet_vite_vuejs.Model;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Configuration;

namespace dotnet_vite_vuejs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = createWebBuilder(args);
            var startup = new Startup(builder, builder.Environment);
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            startup.Configure(app, app.Environment);
            app.Run();
        }
        private static WebApplicationBuilder createWebBuilder(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            return builder;
        }
    }
}