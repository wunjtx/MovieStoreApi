using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface ICastRepository:IRepository<Cast>
    {
        IEnumerable<Cast> GetCastInMovie(int movieId);
    }
}
