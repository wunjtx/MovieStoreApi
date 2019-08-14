using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public GenreService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public Genre GetGenreById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
