using System;
using dotnet_vite_react.Repository;
using dotnet_vite_react.Model;
using dotnet_vite_react.AppContext;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace dotnet_vite_react.UnitOfWorkApp
{
    public class UnitOfWork : IDisposable
    {
        public IBaseRepository<Course> course { get; set; }
        public IBaseRepository<Student> students { get; set; }
        public IBaseRepository<Enrollment> enrollment { get; set; }
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
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        public IBaseRepository<T>? GetRepo<T>() where T : class
        {
            Type type = this.GetType();
            PropertyInfo[] prop = type.GetProperties();
            //foreach ( PropertyInfo propInfo in prop )
            //{
            //    if (propInfo.PropertyType == (typeof(IBaseRepository<T>))){
            //        Console.WriteLine("");
            //    };
            //    var c = typeof(IBaseRepository<T>);
            //    if ( propInfo.PropertyType == typeof(IBaseRepository<T>)) { Console.WriteLine(""); };
            //    if ( propInfo.PropertyType == typeof(IBaseRepository<T>))
            //    {
            //        return (IBaseRepository<T>?)propInfo?.GetValue(this);
            //    }
            //}
            //return null;
            PropertyInfo? propertyInfo = type.GetProperties().FirstOrDefault(t => t.PropertyType == typeof(IBaseRepository<T>));
            return (IBaseRepository<T>?)propertyInfo?.GetValue(this);

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
