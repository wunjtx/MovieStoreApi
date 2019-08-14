using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Entities;
//using MovieStore.Services.DTO;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.DTO;

namespace MovieStoreApi.Controllers
{
    /*
     * 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly ICrewService _crewService;
        private readonly IMapper _mapper;
        public CrewController(ICrewService crewService, IMapper mapper)
        {
            _crewService = crewService;
            _mapper = mapper;
        }

        //Crew CrewDTO api/crew/1 GET NO Get that crew info with movies he/she in 
        [HttpGet]
        [Route("{movieId:int}")]
        public IActionResult GetCrewInMovie(int movieId)
        {
            var crew = _crewService.GetCrewInMovie(movieId);
            var crewDto = _mapper.Map<IEnumerable<Crew>, IEnumerable<CrewDTO>>(crew);
            return Ok(crewDto);
        }
    }
}