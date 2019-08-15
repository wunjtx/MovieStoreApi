using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }

        public Genre GetGenreById(int id)
        {
            return _genreRepository.GetById(id);
        }
    }
}
