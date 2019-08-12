using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.DTO;
using MovieStoreApi.Utilities;

namespace MovieStoreApi.Controllers
{
    /*
     * 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper  _mapper;
        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        
        //201 Created api/admin/movies POST Admin Admin can add new movie to catalog
        [HttpPost]
        [Route("movies")]
        public IActionResult AddMovie([FromBody] MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Request!!");
            }
            var movie = _adminService.AddNewMovie(_mapper.Map<MovieDTO,Movie>(movieDTO));
            return Ok(movie);
        }

        //200 Ok api/admin/movies GET  Admin Get All Movies - server-side pagination
        [HttpGet]
        [Route("movies")]
        public IActionResult ShowAllMovies([FromQuery]PageDTO page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed");
            }
            var totalRecords = _adminService.TotalMovieRecords(page.Filter);
            var movies = _adminService.ShowAllMovies(page);
            var movieDto = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
            var pageData = new PagedResultSet<MovieDTO>(page: page.Index, pageSize: page.PageSize, totalRecords: totalRecords, data: movieDto);
            return Ok(pageData);
        }

        //200 OK api/admin/movies/1 PUT Admin Admin can update a Movie with new information 
        [HttpPut]
        [Route("movies/{index:int}")]
        public IActionResult UpdateMovie(int index,[FromBody] MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("bad request");
            }
            var movie = _mapper.Map<MovieDTO, Movie>(movieDto);
            movie = _adminService.UpdateMovie(movie);
            if (movie != null)
                return Ok(movie);
            return BadRequest("Bad Request");
        }

        //UserDTO  api/admin/users GET Admin Get all Users info to admin 
        [HttpGet]
        [Route("users")]
        public IActionResult GetAllUserInfo([FromQuery]PageDTO page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var totalRecords = _adminService.TotalUserRecords(page.Filter);
            var users = _adminService.GetAllUserInfo(page);
            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            var pageData = new PagedResultSet<UserDTO>(page: page.Index, pageSize: page.PageSize, totalRecords: totalRecords, data: userDto);
            return Ok(pageData);
        }

        //PurchaseDTO api/admin/userpurchases GET Admin Get all Users list who made purchases 
        [HttpGet]
        [Route("userpurchases")]
        public IActionResult GetAllPurchasedUser([FromQuery]PageDTO page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var totalRecords = _adminService.TotalPurchaseRecords(page.Filter);
            var uses = _adminService.GetAllPuchasedUser(page);
            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(uses);
            var pageData = new PagedResultSet<UserDTO>(page: page.Index, pageSize: page.PageSize, totalRecords: totalRecords, data: userDto);
            return Ok(pageData);
        }

        //Purchases api/admin/purchases  GET Admin Admin to get all the purchases 
        [HttpGet]
        [Route("purchases")]
        public IActionResult GetAllPurchases([FromQuery]PageDTO page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var totalRecords = _adminService.TotalPurchaseRecords(page.Filter);
            var purchases = _adminService.GetAllPuchases(page);
            var purchasesDto = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseDTO>>(purchases);
            var pageData = new PagedResultSet<PurchaseDTO>(page: page.Index, pageSize: page.PageSize, totalRecords: totalRecords, data: purchasesDto);
            return Ok(pageData);
        }

        //PurchaseDetailsDTO api/admin/movies/purchases/1 GET Admin Admin to get all purchases for that movie 
        [HttpGet]
        [Route("movies/purchase/{movieId:int}")]
        public IActionResult GetAllPurchasesForMovie([FromQuery]PageDTO page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var totalRecords = _adminService.TotalPurchaseMovieRecords(page.Filter);
            var purchases = _adminService.GetAllPuchasesForMovie(page);
            var purchasesDto = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseDTO>>(purchases);
            var pageData = new PagedResultSet<PurchaseDTO>(page: page.Index, pageSize: page.PageSize, totalRecords: totalRecords, data: purchasesDto);
            return Ok(pageData);
        }
    }
}