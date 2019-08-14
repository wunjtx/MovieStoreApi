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
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMovieService movieService, IMapper mapper)
        {
            _genreService = genreService;
            _movieService = movieService;
            _mapper = mapper;
        }

        //GenreDTO api/genres GET NO Get all genres for navigation menu 
        [HttpGet]
        [Route("")]
        public IActionResult GetAllGenres()
        {
            var genres = _genreService.GetAllGenres();
            var genreDto = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(genres);
            return Ok(genreDto);
        }
    }
}