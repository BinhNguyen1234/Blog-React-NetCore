using dotnet_vite_react.AppContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace dotnet_vite_react.Repository
{
    public class Repository <T> : IBaseRepository<T> where T : class
    { 
        public Repository(Context context)
        {
            this.DbContext = context;
        }

        public DbSet<T> DbSet { 
            get
            {
                return DbContext.Set<T>();
            }
        }

        public DbContext DbContext { get; set; }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
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
        DbSet<T> DbSet { get; }
        DbContext DbContext { get; }
        void Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(T entity);
        void SaveChanges();
    }
}
