using Microsoft.EntityFrameworkCore;
using dotnet_vite_vuejs.Model;
using Microsoft.Extensions.Logging;

namespace dotnet_vite_react
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        public DbSet<Persons> Person { get; set; }
    }
}
