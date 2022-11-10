using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace penca.lb.data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All(Expression<Func<T, bool>> includeFilters = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> AllNoTracking(int page, int pageSize, Expression<Func<T, bool>> includeFilters = null, params Expression<Func<T, object>>[] includeProperties);
        T GetById(long id, params Expression<Func<T, object>>[] includeProperties);
        T Create(T entity);
        void Edit(T entity);
        void Delete(long id);
        void Delete(T entity);
        void Save();
        Task SaveAsync();
        void Attach(T entity);
    }
}

