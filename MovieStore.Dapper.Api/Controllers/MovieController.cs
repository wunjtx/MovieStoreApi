using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;

namespace MovieStore.Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateMovie(Movie movie)
        {
            var nm = _movieService.AddMovie(movie);
            return Ok();
        }


        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAllMoviesAsync([FromQuery]PageDTO pageDTO)
        {
            var nm = await _movieService.GetAllMoviesAsync(pageDTO);
            return Ok(nm);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateMovieAsync([FromBody]Movie movie)
        {
            await _movieService.UpdateMovieAsync(movie);
            return Ok(movie);
        }

        [HttpGet]
        [Route("getpurchased/{id:int}")]
        public async Task< IActionResult> GetPurchasedMovies(int id)
        {

            await _movieService.GetPurchasedMovies(id);
            return Ok();
        }
        
    }
}