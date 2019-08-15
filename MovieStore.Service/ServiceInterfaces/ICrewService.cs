using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface ICrewService
    {
        IEnumerable<Crew> GetCrewInMovie(int movieId);
    }
}
