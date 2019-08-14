using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Dapper.Services.Interface
{
    public interface IMovieService
    {
        Movie GetMovieById(int id);
        int GetTotalMovies(string name = "");
        IEnumerable<Movie> GetTopGrossingMovies(int count = 20);
        IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "");
        Movie AddMovie(Movie movie);
        IEnumerable<Movie> GetMovieByTitle(string title);
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        IEnumerable<Movie> GetAllMovies(PageDTO page);
        IEnumerable<Movie> GetMoviesCarousel(string title = "", int count = 6);
        IEnumerable<RatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "");
        Movie UpdateMovie(Movie movie);
        Task<IEnumerable<Movie>> GetAllMoviesAsync(PageDTO page);
        Task UpdateMovieAsync(Movie movie);
        Task<IEnumerable< Purchase>> GetPurchasedMovies(int id);
    }
}
