using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.Mvc.Infrastructure.Exception;
using MovieStoreMovieStoreApi.Mvc.Infrastructure.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
        //[Route("api/{id:int}")]
        public async Task<ActionResult> ConsumeApi(int id)
        {
            string Baseurl = "https://localhost:44324/";
            Movie movie;

            /*
            //You must change the path to point to your .cer file location. 
            X509Certificate Cert = X509Certificate.CreateFromCertFile("C:\\mycert.cer");
            // Handle any certificate errors on the certificate from the server.
            ServicePointManager.CertificatePolicy = new CertPolicy();
            // You must change the URL to point to your Web server.
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://YourServer/sample.asp");
            Request.ClientCertificates.Add(Cert);
            Request.UserAgent = "Client Cert Sample";
            Request.Method = "GET";
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            */

            using (var client = new HttpClient())
            {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"movie/{id}");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var MvResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    movie = JsonConvert.DeserializeObject<Movie>(MvResponse);

                    //returning the employee list to view  
                    return View(movie);
                }
                return View("Error");
            }
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
