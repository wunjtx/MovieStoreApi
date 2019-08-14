using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class CrewService : ICrewService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public CrewService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public IEnumerable<Crew> GetCrewInMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
