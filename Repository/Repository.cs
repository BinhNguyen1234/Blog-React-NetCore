using dotnet_vite_react.AppContext;
using dotnet_vite_react.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace dotnet_vite_react.Repository
{
    public class Repository<T> : IBaseRepository<T> where T : class
    {
        public DbContext DbContext { get; set; }
        public DbSet<T> dbSet { get; }


        public Repository(Context context)
        {
            this.DbContext = context;
            dbSet = this.DbContext.Set<T>();
        }



        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges() => DbContext.SaveChanges();

        public T Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> dbSet { get; }
        DbContext DbContext { get; }
        void Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(T entity);
        void SaveChanges();
    }
    public static class RepositoryExtension
    {
        public static void AddRegisteredRepository(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<EnrollmentEntity>, Repository<EnrollmentEntity>>();
            services.AddScoped<IBaseRepository<StudentEntity>, Repository<StudentEntity>>();
            services.AddScoped<IBaseRepository<CourseEntity>, Repository<CourseEntity>>();
        }
    }
}
