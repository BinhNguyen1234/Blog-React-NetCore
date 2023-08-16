using Microsoft.Extensions.DependencyInjection;
using dotnet_vite_vuejs.Testservice;
namespace dotnet_vite_vuejs
{
    public static class ServiceExtension
    {
        public static void AddTest(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }
    }
}
