using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class MovieService :Service<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public IEnumerable<Movie> GetTopGrossingMovies(int count = 20)
        {
            return _movieRepository.GetTopGrossingMovies(count);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }
        
        public int GetTotalMovies(string name = "")
        {
            return _movieRepository.GetTotalRecords(m => m.Title == name);
        }
        public IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            return _movieRepository.GetMoviesByPagination(page, pageSize, titleFilter);
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _movieRepository.GetMoviesByGenre(genreId);
        }

        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            return string.IsNullOrEmpty(title) ? _movieRepository.GetAll() : _movieRepository.GetMovieByTitle(title);
        }

        public IEnumerable<Movie> GetMoviesCarousel(string title = "", int count = 6)
        {
            return _movieRepository.GetMoviesCarousel(title, count);
        }

        public IEnumerable<IRatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            return _movieRepository.GetTopRatedMovies(page, pageSize, titleFilter);
        }

        public Movie AddMovie(Movie movie)
        {
            _movieRepository.Add(movie);
            _movieRepository.SaveChanges();
            return movie;
        }

        public IEnumerable<Movie> GetAllMovies(PageDTO page)
        {
            return _movieRepository.GetMoviesByPagination(page.Index,page.PageSize,page.Filter);
        }

        protected override void SetCurrentRepository()
        {
            base.repository=_movieRepository;
        }

        public Movie UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
            _movieRepository.SaveChanges();
            return movie;
        }
    }
}
