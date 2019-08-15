using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface IMovieRepository:IRepository<Movie>
    {
        IEnumerable<Movie> GetTopGrossingMovies(int count = 20);
        IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "");
        IEnumerable<Movie> GetMoviesByGenre(int genreId=1);
        IEnumerable<Movie> GetMovieByTitle(string title);
        IEnumerable<Movie> GetMoviesCarousel(string title = "", int count = 6);
        IEnumerable<Movie> GetSomeMovies(Expression<Func<Movie,bool>> expression);
        IEnumerable<RatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "");
    }
}
