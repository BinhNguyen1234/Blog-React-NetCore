using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace dotnet_vite_react.Repository
{
    public class Repository <T> : IBaseRepository<T> where T : class
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            this._context = context;
        }
        public void SaveChanges() => _context.SaveChanges();
    }
    public interface IBaseRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Get(T entity);
        void SaveChanges();
    }
}
