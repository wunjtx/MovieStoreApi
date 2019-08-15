using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class CrewService : ICrewService
    {
        private readonly ICrewRepository _crewRepository;
        public CrewService(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }
        public IEnumerable<Crew> GetCrewInMovie(int movieId)
        {
            return _crewRepository.GetCrewInMovie(movieId);
        }
    }
}
