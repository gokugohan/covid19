using Covid19.Contracts;
using Covid19.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext Context { get; set; }
        protected DbSet<T> dbSet;
        private bool disposed = false;
        public RepositoryBase(RepositoryContext context)
        {
            this.Context = context;
            this.dbSet = this.Context.Set<T>();
        }


        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (this.Context.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            this.dbSet.Remove(entity);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.dbSet.FirstOrDefault(expression);
        }

        public Task<T> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.dbSet.FirstOrDefaultAsync(expression);
        }


        public IQueryable<T> FindAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if (orderBy != null)
            {
                return orderBy(this.dbSet).AsNoTracking();
            }
            return this.dbSet.AsNoTracking();
        }

        public Task<List<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if (orderBy != null)
            {
                orderBy(this.dbSet).ToListAsync();
            }
            return this.dbSet.ToListAsync();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if (orderBy != null)
            {
                return orderBy(this.dbSet.Where(expression)).AsNoTracking();
            }
            return this.dbSet.Where(expression).AsNoTracking();
        }

        public async Task<List<T>> FindByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            if (orderBy != null)
            {
                return await orderBy(this.dbSet.Where(expression)).ToListAsync();
            }
            return await this.dbSet.Where(expression).ToListAsync();
        }

        public int Total()
        {
            return this.dbSet.Count();
        }

        public void Update(T entity)
        {
            this.dbSet.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            this.dbSet.UpdateRange(entities);
        }

        public async Task<T> FindAsync(object key)
        {
            return await this.dbSet.FindAsync(key);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
