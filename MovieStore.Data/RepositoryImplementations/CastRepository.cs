using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieStore.Data.RepositoryImplementations
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieStoreDbContext movieStoreDbContext) : base(movieStoreDbContext)
        {
        }

        public IEnumerable<Cast> GetCastInMovie(int movieId)
        {
            return _movieStoreDbContext.Casts.Where(c=>c.MovieCast.Any(mc=>mc.MovieId==movieId)).ToList();
        }
    }
}
