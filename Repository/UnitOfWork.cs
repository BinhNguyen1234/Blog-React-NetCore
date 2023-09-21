using System;
using dotnet_vite_react.Repository;
using dotnet_vite_react.Model;
using dotnet_vite_react.AppContext;
namespace dotnet_vite_react.UnitOfWorkApp
{
    public class UnitOfWork : IDisposable
    {
        public IBaseRepository<Course> course;
        public IBaseRepository<Student> students;
        public IBaseRepository<Enrollment> enrollment;
        public Context context { get; set; }
        public UnitOfWork(Context context,
            IBaseRepository<Course> course,
            IBaseRepository<Student> students,
            IBaseRepository<Enrollment> enrollment
            ) {
            this.context = context;
            this.course = course;
            this.students = students;
            this.enrollment = enrollment;
        }
        public void SaveChages()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Console.WriteLine("Unit of work dispose");
        }
    }
}
