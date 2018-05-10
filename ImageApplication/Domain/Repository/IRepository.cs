using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository <T>
    {
        void Add(T entity);
        void AddOrUpdate(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);

        T Find(T entity);
        IEnumerable<T> GetAll();
        IQueryable<T> Include(string field);
        IQueryable<T> Take(int count);
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
    }
}
