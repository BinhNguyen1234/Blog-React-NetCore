using dotnet_vite_react.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
namespace dotnet_vite_react.AppContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Console.WriteLine("Context init");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        public DbSet<StudentEntity> Persons { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
    }
}
