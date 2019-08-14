using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class CastService : ICastService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public CastService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public IEnumerable<Cast> GetCastInMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
