using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface IRepository<T> where T:class
    {
        int GetAllRecords(Expression<Func<T, bool>> whereConditon);
        IEnumerable<T> GetAll();
        bool Exist(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Update(T entity);
        void Add(T entity);
        IEnumerable<T> GetByWhere(Expression<Func<T, bool>> whereLambda);
        int GetTotalRecords(Expression<Func<T, bool>> whereLambda = null);
        void SaveChanges();
        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
        IQueryable<T> GetQueryableData(out int totalCount, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
    }
}
