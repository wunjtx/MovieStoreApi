using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.WebApi.Infrastructure.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieStoreApi.WebApi.Controllers
{
    //[RoutePrefix("movie")] //if add routePrefix the default route config will not work
    //[ExceptionHandling]
    public class MovieController : ApiController
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: api/Movie
        [HttpGet]
        //[Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            //var movie = _movieService.GetMovieById(id);
            //return Ok(movie);
            int i1 = 1;
            int i2 = 0;
            int i3 = i1 / i2;
            return Ok();
        }

        // POST: api/Movie
        [HttpGet]
        //[Route("errortest")]
        public IHttpActionResult ErrorTest([FromBody]string value)
        {
            int i1 = 1;
            int i2 = 0;
            int i3 = i1 / i2;
            return Ok();
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
