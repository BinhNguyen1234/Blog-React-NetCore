using Microsoft.EntityFrameworkCore;
using dotnet_vite_react.Model;
using Microsoft.Extensions.Logging;

namespace dotnet_vite_react.AppContext
{
    public class PoolContext : DbContext
    {
        public PoolContext(DbContextOptions<PoolContext> options) : base(options) { }
        public DbSet<StudentEntity> Persons { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

    }
}
