﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Entities;
//using MovieStore.Services.DTO;
using MovieStore.Services.ServiceInterfaces;
using MovieStoreApi.DTO;
using MovieStoreApi.Utilities;

namespace MovieStoreApi.Controllers
{
    /*
     * 
     * UserDTO api/user/1 GET User Get Logged in user info
     * 200 Ok Token api/login POST None User Logged in and got JWT token back 
     * 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IMapper mapper, IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;
        }

        //
        //[HttpGet]
        //[Route("{id:int}")]
        //public IActionResult GetUserDetails(int id)
        //{
        //    var user = _userService.GetUserDetails(id);
        //    return Ok(user);
        //}

        //201 Created api/user POST NO Create new Account/user 
        [HttpPost]
        [Route("Register")]
        public IActionResult CreateUser([FromBody] UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdUser = _userService.CreateUser(user.UserName, user.Password);
            if (createdUser == null)
            {
                return BadRequest("Check User Name / Password!!!");
            }
            return Ok(user);
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var loginUser = _userService.ValidateUser(user.UserName, user.Password);
            if (loginUser == null)
            {
                return BadRequest("Login Failed!!");
            }
            var token = new { token = GenerateJWTToken(loginUser) };
            return Ok(token);
        }

        private string GenerateJWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim("alias", user.FirstName[0] + user.LastName[0].ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
            };

            //var roles = _userService.GetUserRoles(user.Email).GetAwaiter().GetResult();
            //foreach (var role in roles)
                // make sure you have role with small "r" as Authorization looks for role with comma separated array
            //    claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenSettings:PrivateKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["TokenSettings:ExpirationDays"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _config["TokenSettings:Issuer"],
                Audience = _config["TokenSettings:Audience"]
            };

            var encodedJwt = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(encodedJwt);
        }


        //200 OK api/user/purchase POST User User made a movie purchase 
        [HttpPost]
        [Route("purchase")]
        public IActionResult AddPurchaseMovie(PurchaseDTO purchaseDTO)
        {
            if (!ModelState.IsValid)
            {
                return Forbid("failed!!");
            }
            purchaseDTO.PurchaseDateTime = DateTime.Now;
            purchaseDTO.PurchaseNumber = Guid.NewGuid();
            purchaseDTO.TotalPrice = _userService.GetTotalPrice(purchaseDTO.MovieId);
            var purchase = _mapper.Map<PurchaseDTO, Purchase>(purchaseDTO);
            if (_userService.AddPurchaseMovie(purchase) != null)
                return Ok("success purchased!!");
            else
                return BadRequest("failed!!");
        }


        [HttpGet]
        [Route("ispurchased/{userId}/{movieId:int}")]
        public IActionResult IsMoviePurchased(string username, int movieId)
        {
            var boo = _userService.IsMoviePurchased(username, movieId);
            return Ok(boo);
        }


        [HttpGet]
        [Route("isfavorited/{userId:int}/{movieId:int}")]
        public IActionResult IsMovieFavortied(int userId, int movieId)
        {
            var boo = _userService.IsMovieFavorited(userId, movieId);
            return Ok(boo);
        }


        //200 OK api/user/favorite POST User User added a movie to his Favorites
        [HttpPost]
        [Route("favorite")]
        public IActionResult AddFavoriteMovie(FavoriteDTO favoriteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed favorite!!");
            }
            var favorite = _mapper.Map<FavoriteDTO, Favorite>(favoriteDto);
            if (_userService.AddFavoriteMovie(favorite) != null)
                return Ok("success favorite!!");
            else
                return BadRequest("failed favorite!!");
        }


        //UserDto  user pagination 
        [HttpGet]
        [Route("page/{index:int}")]
        public IActionResult MyFavoritedMovies(int index, int pageSize = 20, string filter = "")
        {
            var users = _userService.GetUserPagination(index, pageSize, filter);
            var userDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            var totalUsers = _userService.GetAllUsers(filter);
            var pageSet = new PagedResultSet<UserDTO>(page: index, pageSize: pageSize, totalRecords: totalUsers, data: userDto);
            return Ok(pageSet);
        }


        //MovieDTO api/user/favorites GET User Get Logged in user's favorite movies 
        [HttpGet]
        [Route("favorites/{userId:int}")]
        public IActionResult MyFavoritedMovies(int userId)
        {
            var favorites = _userService.AllFavoritedMovies(userId);
            var movies = _mapper.Map<IEnumerable<Favorite>, IEnumerable<MovieDTO>>(favorites);
            return Ok(movies);
        }


        //MovieDTO api/users/mymovies GET User Movies purchased my particular User 
        [HttpGet]
        [Route("mymovies/{userId:int}")]
        public IActionResult MyPurchasedMovies(int userId)
        {
            var purchase = _userService.AllPurchasedMovies(userId);
            var movies = _mapper.Map<IEnumerable<Purchase>, IEnumerable<MovieDTO>>(purchase);
            return Ok(movies);
        }


        //ReviewDTO api/user/reviews GET User Get Logged in user's reviews/ratings of movies 
        [HttpGet]
        [Route("reviews/{userId:int}")]
        public IActionResult GetUserReviews(int userId)
        {
            var reviews = _userService.GetUserReviews(userId);
            var reviewDto = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(reviews);
            return Ok(reviewDto);
        }


        //200 OK api/user/review POST User User added a movie review/rating
        [HttpPost]
        [Route("review")]
        public IActionResult AddReviewToMovie([FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed");
            }
            if (_userService.AddReviewToMovie(_mapper.Map<ReviewDTO, Review>(reviewDto)) != null)
                return Ok("success favorite");
            else
                return BadRequest("failed");
        }


        //200 OK api/user/1 PUT User User updated his/her info 
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed");
            }
            //if (_userService.UpdateUser(_mapper.Map<UserDTO, User>(userDTO)) != null)
            //    return Ok("success update user");
            //else
            //    return BadRequest("failed");
            if (_userService.UpdateUser(userDTO) != null)
                return Ok("success update user");
            else
                return BadRequest("failed");

        }

        //200 OK api/user/review PUT User User updated his/her rating/review of a movie 
        [HttpPut]
        [Route("review")]
        public IActionResult UpdateReview([FromBody] ReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("failed");
            }
            if (_userService.UpdateReview(_mapper.Map<ReviewDTO, Review>(reviewDTO)) != null)
                return Ok("success update review");
            return BadRequest("failed");
        }

        ////update partial information
        //[HttpPatch]
        //[Route("patch/{id:int}")]
        //public IActionResult PatchUser([FromBody] UserPatchDTO patch)
        //{
        //    var tempuser = _userService.GetUserById(patch.Id);
        //    tempuser.FirstName = patch.FirstName;
        //    tempuser.Email = patch.Email;
        //    _userService.SaveChanges();
        //    return Ok();
        //}

    }
}