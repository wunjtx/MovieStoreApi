using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface ICrewRepository:IRepository<Crew>
    {
        IEnumerable<Crew> GetCrewInMovie(int movieId);
    }
}
