using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public UserService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public Favorite AddFavoriteMovie(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Purchase AddPurchaseMovie(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public Review AddReviewToMovie(Review review)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> AllFavoritedMovies(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> AllFavoritedMovies(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> AllPurchasedMovies(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> AllPurchasedMovies(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> AllPurchasedMovies(int userId)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string username, string password, int[] roles = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAllPurchasesForMovie(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers(PageDTO pageDTO)
        {
            throw new NotImplementedException();
        }

        public int GetAllUsers(string filter = "")
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetTotalUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUserPagination(int index = 1, int pageSize = 20, string filter = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetUserReviews(int userId)
        {
            throw new NotImplementedException();
        }

        public bool IsAddReview(string username, int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsAddReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsMovieFavorited(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsMovieFavorited(string username, int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsMoviePurchased(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public bool IsMoviePurchased(string username, int movieId)
        {
            throw new NotImplementedException();
        }

        public Review UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public User ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
