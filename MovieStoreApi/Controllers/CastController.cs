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
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;
        private readonly IMapper _mapper;

        public CastController(ICastService castService, IMapper mapper)
        {
            _castService = castService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("{movieId:int}")]
        public IActionResult GetCastInMovie(int movieId)
        {
            var cast = _castService.GetCastInMovie(movieId);
            var castDto = _mapper.Map<IEnumerable<Cast>, IEnumerable<CastDTO>>(cast);
            return Ok(castDto);
        }
    }
}