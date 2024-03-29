﻿using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieStore.Entities;

namespace MovieStoreApi.MvcAndWebApi.Controllers
{
    //[RoutePrefix("movieapi")]
    public class MovieApiController : ApiController
    {
        private readonly IMovieService _movieServices;
        public MovieApiController(IMovieService movieServices)
        {
            _movieServices = movieServices;
        }

        // GET: api/MovieApi
        [HttpGet]
        //[Route("get")]
        public IHttpActionResult Get(int id)
        {
            var movies = _movieServices.GetAllMovies(new PageDTO() { Index=1,PageSize=20 });
            return Ok(movies);
        }

        // POST: api/MovieApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MovieApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MovieApi/5
        public void Delete(int id)
        {
        }
    }
}
