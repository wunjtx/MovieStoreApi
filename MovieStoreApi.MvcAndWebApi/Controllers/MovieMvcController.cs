using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.MvcAndWebApi.Controllers
{
    public class MovieMvcController : Controller
    {
        private readonly IMovieService _movieServices;
        public MovieMvcController(IMovieService movieServices)
        {
            _movieServices = movieServices;
        }
        // GET: MovieMvc
        public ActionResult Index()
        {
            var movies = _movieServices.GetAllMovies(new PageDTO() { Index = 1, PageSize = 20 });
            return View(movies);
        }

        // GET: MovieMvc/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movieServices.GetMovieById(id);
            return View(movie);
        }

        // GET: MovieMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieMvc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieMvc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieMvc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieMvc/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = _movieServices.GetMovieById(id);
            return View(movie);
        }

        // POST: MovieMvc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
