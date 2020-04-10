using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Covid19.Contracts
{
    public interface IRepositoryBase<T>
    {
        T Find(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(object key);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);


        IQueryable<T> FindAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<List<T>> FindAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        void Add(T entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        int Total();
        void Dispose(bool disposing);
        void Dispose();
    }
}
