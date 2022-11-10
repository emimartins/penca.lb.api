using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using penca.lb.data.Model;

namespace penca.lb.data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private DbContext _context;
        private DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
            //_context.ChangeTracker.AutoDetectChangesEnabled = false;
        }


        public IQueryable<T> All(Expression<Func<T, bool>> includeFilters = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbset.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (includeFilters != null)
                query = query.Where(includeFilters);

            return query;
        }

        public IQueryable<T> AllNoTracking(int page, int pageSize, Expression<Func<T, bool>> includeFilters = null, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            AddEntityTrackDates();
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        private void AddEntityTrackDates()
        {
            var entities = _context.ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                DateTime now = DateTime.UtcNow;
                if (entity.State == EntityState.Added)
                    ((Entity)entity.Entity).DateCreated = now;
                ((Entity)entity.Entity).LastUpdated = now;
            }
        }
    }
}

