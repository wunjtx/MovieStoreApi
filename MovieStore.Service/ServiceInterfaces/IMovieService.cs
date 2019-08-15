using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface IMovieService:IService<Movie>
    {
        Movie GetMovieById(int id);
        int GetTotalMovies(string name = "");
        /// <summary>
        /// Get 20 highest grossing (revenue) movies 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetTopGrossingMovies(int count = 20);
        IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "");
        Movie AddMovie(Movie movie);
        IEnumerable<Movie> GetMovieByTitle(string title);
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        IEnumerable<Movie> GetAllMovies(PageDTO page);
        IEnumerable<Movie> GetMoviesCarousel(string title = "", int count=6);
        IEnumerable<IRatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "");
        Movie UpdateMovie(Movie movie);
    }
}
