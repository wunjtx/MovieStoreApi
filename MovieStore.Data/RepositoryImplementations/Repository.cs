using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieStore.Data.RepositoryInterfaces;

namespace MovieStore.Data.RepositoryImplementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly  MovieStoreDbContext _movieStoreDbContext;
        public Repository(MovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }
        public void Add(T entity)
        {
            _movieStoreDbContext.Set<T>().Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _movieStoreDbContext.Set<T>().Any(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _movieStoreDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _movieStoreDbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetByWhere(Expression<Func<T, bool>> whereLambda)
        {
            return _movieStoreDbContext.Set<T>().Where(whereLambda).ToList();
        }

        public int GetTotalRecords(Expression<Func<T, bool>> whereLambda = null)
        {
            return whereLambda != null ? _movieStoreDbContext.Set<T>().Where(whereLambda).Count() : _movieStoreDbContext.Set<T>().Count();
        }

        public void SaveChanges()
        {
            _movieStoreDbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            //_movieStoreDbContext.Add(entity);
            _movieStoreDbContext.Entry(entity).State= EntityState.Modified;
            return entity;
        }

        public IEnumerable<T> GetPaginationByCondition<S>(Expression<Func<T, bool>> whereConditon, Expression<Func<T, S>> orderConditon, int page = 1, int pageSize = 20)
        {
            return _movieStoreDbContext.Set<T>().Where(whereConditon).OrderBy(orderConditon).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetAllRecords(Expression<Func<T, bool>> whereConditon)
        {
            return _movieStoreDbContext.Set<T>().Where(whereConditon).ToList().Count();
        }

        public void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            var dbEntityEntry = _movieStoreDbContext.Entry(entity);

            if (updatedProperties.Any())
            {
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                foreach (var property in dbEntityEntry.OriginalValues.Properties)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                    {
                        dbEntityEntry.Property(property.Name).IsModified = true;
                    }
                }
            }
            //return dbContext.SaveChanges();
        }
        public IQueryable<T> GetQueryableData(out int totalCount, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null,
            int? skip = null,
            int? take = null)

        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<T> query = _movieStoreDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            totalCount = query.Count();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
