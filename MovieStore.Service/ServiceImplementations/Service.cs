using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public abstract class Service <T> : IService<T> where T:class
    {
        
        public Service()
        {
            SetCurrentRepository();
        }
        protected IRepository<T> repository;
        protected abstract void SetCurrentRepository();
        public int GetAllRecords(Expression<Func<T, bool>> whereConditon)
        {
            return repository.GetTotalRecords(whereConditon);
        }
    }
}
