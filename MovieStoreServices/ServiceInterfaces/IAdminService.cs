using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface IAdminService
    {
        Movie AddNewMovie(Movie movie);
        IEnumerable<Movie> ShowAllMovies(PageDTO pageDTO);
        //int TotalRecords(string Filter);
        Movie UpdateMovie(Movie movie);//need check exist
        IEnumerable<User> GetAllUserInfo(PageDTO pageDTO);
        IEnumerable<Purchase> GetAllPuchases(PageDTO pageDTO);
        IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO);
        IEnumerable<Purchase> GetAllPuchasesForMovie(PageDTO pageDTO);
        int TotalPurchaseRecords(string filter = "");
        int TotalMovieRecords(string filter = "");
        int TotalUserRecords(string filter = "");
        int TotalPurchaseMovieRecords(string filter = "");
    }
}
