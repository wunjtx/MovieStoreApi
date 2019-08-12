using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public IEnumerable<Cast> GetCastInMovie(int movieId)
        {
            return _castRepository.GetCastInMovie(movieId);
        }
    }
}
