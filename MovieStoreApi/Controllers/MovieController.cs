using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStore.Data;
using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
//using MovieStore.Services.DTO;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.DTO;
using MovieStoreApi.Infrastructure.Filter;
using MovieStoreApi.Infrastructure.Log;
using MovieStoreApi.Utilities;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AddHeader("Author", "NJ")]
    [TypeFilter(typeof(AddHeaderResultServiceFilter), Arguments =new object []{1,"str2","str1"})] //if do not add to service can use typefilter
    //[ServiceFilter(typeof(AddHeaderResultServiceFilter)] //servicefilter can not pass paramter
    public class MovieController : ControllerBase
    {
        private ILoggerManager _logger;

        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly IConfiguration _configuration;
        private readonly IRatingDTO _ratingDTO;
        public MovieController(IMovieService movieService, IMapper mapper, IConfiguration configuration, IRatingDTO ratingDTO, ILoggerManager logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _configuration = configuration;
            _ratingDTO = ratingDTO;
            _logger = logger;
        }

        //MovieDTO api/movies? title = abc & page = 0 GET  NO Get Movies for Carousel
        [HttpGet]
        [Route("")]
        public IActionResult GetMoviesCarousel(string title="",int page=0)
        {
            var movies = _movieService.GetMoviesCarousel(title, _configuration.GetValue<int>("CarouselCount", 6));
            var movieDto = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
            return Ok(movieDto);
        }

        //MovieDetailDTO api/movies/1 GET NO Get Movie Details for page
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            var movieDto = _mapper.Map<Movie, MovieDetailDTO>(movie);
            return Ok(movieDto);
        }

        // Todo
        //MovieDTO api/movies/topgrossing GET NO Get Highest Grossing Movie list for Movie Cards 
        [HttpGet]
        [Route("topgrossing")]
        public IActionResult GetTopGrossingMovies()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return Ok(movies);
        }

        //MovieDTO api/movies/toprated GET NO Get top Movie list for Movie Cards 
        [HttpGet]
        [Route("toprated")]
        public IActionResult GetTopRatedMovies()
        {
            var ratings = _movieService.GetTopRatedMovies();
            //var ratingDto = _mapper.Map<IEnumerable<dynamic>, IEnumerable<RatingDTO>>(ratings);
            var movieDto = _mapper.Map<IEnumerable<IRatingDTO>, IEnumerable<MovieDTO>>(ratings);
            return Ok(movieDto);
        }

        [HttpGet]
        [Route("pagination/{index:int}")]
        public IActionResult GetMovieByPagination(int index , string title = "")
        {
            var movies = _movieService.GetMoviesByPagination(index, 20, title).ToList();
            var totalMovies = _movieService.GetMovieByTitle(title).Count();
            var PageResultmovie = new PagedResultSet<Movie>(index, 20, totalMovies, movies);
            return Ok(PageResultmovie);
        }


        [HttpGet]
        [Route("page/{index:int}")]
        public IActionResult GetMovieByPage(int index = 1,int pageSize = 20, string filter = "")
        {
            IList<MovieDTO> movieDtos = new List<MovieDTO>();
            var movies = _movieService.GetMoviesByPagination(index, pageSize, filter).ToList();
            var movieDto = _mapper.Map<IList<Movie>, IList<MovieDTO>>(movies, movieDtos);
            var totalMovies = _movieService.GetMovieByTitle(filter).Count();
            var PageResultmovie = new PagedResultSet<MovieDTO>(index, 20, totalMovies, movieDto);
            return Ok(PageResultmovie);
        }

        //MovieDTO api/movies/genre/1 GET NO Get List of Movies by Genre
        [HttpGet]
        [Route("genre/{index:int}")]
        public IActionResult GetMovieByGenre(int index = 1)
        {
            var movies = _movieService.GetMoviesByGenre(index);
            return Ok(movies);
        }

        [HttpGet]
        [Route("error")]
        public IActionResult ErrorTesting()
        {
            _logger.LogInfo("Movie Logging Test");

            int i1 = 1;
            int i2 = 0;
            int i3 = i1 / i2;
            return Ok();
        }

    }
}