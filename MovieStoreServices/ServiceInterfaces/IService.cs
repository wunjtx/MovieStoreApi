using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface IService<T> where T:class
    {
        int GetAllRecords(Expression<Func<T, bool>> whereConditon);
    }
}
