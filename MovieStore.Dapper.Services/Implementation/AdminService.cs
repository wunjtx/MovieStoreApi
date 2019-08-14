using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public AdminService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public Movie AddNewMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAllPuchases(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAllPuchasesForMovie(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUserInfo(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> ShowAllMovies(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public int TotalMovieRecords(string filter = "")
        {
            throw new NotImplementedException();
        }

        public int TotalPurchaseMovieRecords(string filter = "")
        {
            throw new NotImplementedException();
        }

        public int TotalPurchaseRecords(string filter = "")
        {
            throw new NotImplementedException();
        }

        public int TotalUserRecords(string filter = "")
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
