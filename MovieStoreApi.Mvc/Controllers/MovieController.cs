﻿using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.Mvc.Infrastructure.Exception;
using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc.Controllers
{
    //public class MovieController : ExceptionHandlingController //catch by controller exception
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        //public MovieController(IMovieService movieService, ILoggerManager loggerManager):base(loggerManager)
        //{
        //    _movieService = movieService;
        //}
        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _movieService.GetAllMovies(new PageDTO() { Index = 1, PageSize = 20 });
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult ErrorTest()
        {
            int i1 = 1;
            int i2 = 0;
            int i3 = i1 / i2;
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
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

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
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

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
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
