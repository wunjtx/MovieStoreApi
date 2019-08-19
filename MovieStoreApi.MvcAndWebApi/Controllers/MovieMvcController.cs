using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
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
        [System.Web.Mvc.HttpPost]
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
            //use normal controller method
            var movieController = new MovieApiController(_movieServices);
            var Res = movieController.Get(id) as OkNegotiatedContentResult<IEnumerable<Movie>>;
            //Deserializing the response recieved from web api and storing into the Employee list  
            var movies =Res.Content;
            return View(movies);


            #region use httpclient
            //Movie movie;
            //using (var client = new HttpClient())
            //{
            //    //for mvc url
            //    /*
            //    var movieDetailUrl = Url.RouteUrl(
            //        "DefaultApi",
            //        new { controller = "MovieApi", action = "", id = id }
            //        );
            //    */

            //    //for api url
            //    /*
            //    var movieDetailUrl = Url.HttpRouteUrl(
            //        "DefaultApi",
            //        new { controller = "MovieApi", httproute = "", id = id }
            //        );
            //    */

            //    // Assuming the API is in the same web application. 

            //    string baseUrl =HttpContext.Request
            //                               .Url
            //                               .GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);

            //    client.BaseAddress = new Uri(baseUrl);

            //    var movieDetailUrl = Url.HttpRouteUrl(
            //        "DefaultApi",
            //        new { controller = "MovieApi", httproute = "", id = id }
            //        );

            //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            //    HttpResponseMessage Res = await client.GetAsync(movieDetailUrl);
            //    //Checking the response is successful or not which is sent using HttpClient  
            //    if (Res.IsSuccessStatusCode)
            //    {
            //        //Storing the response details recieved from web api   
            //        var MvResponse = Res.Content.ReadAsStringAsync().Result;

            //        //Deserializing the response recieved from web api and storing into the Employee list  
            //        movie = JsonConvert.DeserializeObject<IEnumerable< Movie>>(MvResponse);

            //        //returning the employee list to view  
            //        return View(movie);
            //    }
            //    return View("Error");
            //}
            #endregion
        }

        // POST: MovieMvc/Edit/5
        [System.Web.Mvc.HttpPost]
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
        [System.Web.Mvc.HttpPost]
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
