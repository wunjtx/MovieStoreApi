using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class AdminService : IAdminService
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public AdminService(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        public Movie AddNewMovie(Movie movie)
        {
            return _movieService.AddMovie(movie);
        }

        public IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO)
        {
            return _userService.GetAllPuchasedUser(pageDTO);
        }

        public IEnumerable<Purchase> GetAllPuchases(PageDTO pageDTO)
        {
            return _userService.AllPurchasedMovies(pageDTO);
        }

        public IEnumerable<Purchase> GetAllPuchasesForMovie(PageDTO pageDTO)
        {
            return _userService.GetAllPurchasesForMovie(pageDTO);
        }

        public IEnumerable<User> GetAllUserInfo(PageDTO pageDTO)
        {
            return _userService.GetAllUsers(pageDTO);
        }

        public IEnumerable<Movie> ShowAllMovies(PageDTO page)
        {
            return _movieService.GetAllMovies(page);
        }

        public int TotalPurchaseRecords(string filter = "")
        {
            return string.IsNullOrEmpty(filter) ? _userService.TotalPurchaseRecords(m => true) : _userService.TotalPurchaseRecords(m => m.Customer.Email.Contains(filter));
        }
        public int TotalPurchaseMovieRecords(string filter = "")
        {
            int id;
            if( string.IsNullOrEmpty(filter))
            {
                return  _userService.TotalPurchaseRecords(m => true);
            }
            else if(int.TryParse(filter,out id) && id>0)
            {
                return _userService.TotalPurchaseRecords(m => m.MovieId==id);
            }
            else
            {
                return _userService.TotalPurchaseRecords(m => m.Movie.Title.Contains(filter));
            }
        }
        public int TotalMovieRecords(string filter = "")
        {
            return string.IsNullOrEmpty(filter) ? _movieService.GetAllRecords(m => true) : _movieService.GetAllRecords(m => m.Title.Contains(filter));
        }
        public int TotalUserRecords(string filter = "")
        {
            return string.IsNullOrEmpty(filter) ? _userService.GetAllRecords(m => true) : _userService.GetAllRecords(m => m.Email.Contains(filter));
        }

        public Movie UpdateMovie(Movie movie)
        {
            return _movieService.UpdateMovie(movie);
        }
    }
}
