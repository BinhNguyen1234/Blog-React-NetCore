using Microsoft.EntityFrameworkCore;
using dotnet_vite_react.Model;
using Microsoft.Extensions.Logging;

namespace dotnet_vite_react.AppContext
{
    public class PoolContext : DbContext
    {
        public PoolContext(DbContextOptions<PoolContext> options) : base(options) { }
        public DbSet<Student> Persons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
