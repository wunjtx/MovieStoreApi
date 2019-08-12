using Microsoft.EntityFrameworkCore;
using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieStore.Data.RepositoryImplementations
{
    public class CrewRepository : Repository<Crew>, ICrewRepository
    {
        public CrewRepository(MovieStoreDbContext movieStoreDbContext) : base(movieStoreDbContext)
        {
        }

        public IEnumerable<Crew> GetCrewInMovie(int movieId)
        {
            return _movieStoreDbContext.Crews.Where(c => c.MovieCrew.Any(m => m.MovieId == movieId)).ToList();
            //return _movieStoreDbContext.MovieCrews.Include(mc=>mc.Crew).Include(mc=>mc.Movie).Where(c=>c.MovieId==movieId).ToList();
        }
    }
}
