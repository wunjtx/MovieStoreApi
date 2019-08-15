using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MovieStore.Data.RepositoryImplementations
{
    public class MovieRepository:Repository<Movie>,IMovieRepository
    {
        public MovieRepository(MovieStoreDbContext movieStoreDbContext) : base(movieStoreDbContext)
        {
        }
        
        public IEnumerable<Movie> GetMoviesByGenre(int genreId = 1)
        {
            return _movieStoreDbContext.Movies.Where(m => m.MovieGenres.Any(mg => mg.Genre.ID == genreId)).ToList();
        }

        public IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            var query = _movieStoreDbContext.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(titleFilter))
            {
                query = query.Where(m => m.Title.Contains(titleFilter));
            }
            var movies = query.OrderBy(m => m.Title).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return movies;
        }

        public IEnumerable<Movie> GetTopGrossingMovies(int count =20)
        {
            return _movieStoreDbContext.Movies.OrderByDescending(m => m.Revenue).Take(20).ToList();
        }
        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            return _movieStoreDbContext.Movies.Where(d => d.Title.ToLower().Contains( title.ToLower())).ToList();
        }

        public IEnumerable<Movie> GetMoviesCarousel(string title = "", int count = 6)
        {
            return string.IsNullOrEmpty(title) ? GetTopGrossingMovies(6) : _movieStoreDbContext.Movies.Where(m => m.Title.Contains(title)).OrderByDescending(o => o.ReleaseDate).Take(count).ToList();
        }

        public IEnumerable<RatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            //var result =(from moviereviews in _movieStoreDbContext.Reviews
            //            group moviereviews by moviereviews.Movie into mv
            //            from review in mv
            //            select new
            //            {
            //                movie = mv.Key,
            //                totalRating = mv.Sum(m => m.Rating),
            //                totalRatedCount = mv.Where(m => m.Rating > 0).ToList().Count()
            //            }).ToList();
            return  _movieStoreDbContext.Reviews.GroupBy(r => r.Movie).Select(gp =>
                  new RatingDTO
                  {
                      movie = gp.Key,
                      rating = gp.Average(r => r.Rating)
                  }).OrderByDescending(a => a.rating).ToList();
        }

        public IEnumerable<Movie> GetSomeMovies(Expression<Func<Movie, bool>> expression)
        {
            return _movieStoreDbContext.Movies.Where(expression).Select(m => new Movie { Id = m.Id, Title = m.Title }).ToList();
        }
    }
}
