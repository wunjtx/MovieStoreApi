using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceImplementations
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        #region create user /get total user / get user detail /ValidateUser/GetUserPagination /update user
        public User CreateUser(string username, string password, int[] roles = null)
        {
            var dbUser = _userRepository.GetUserByUserName(username);
            if (dbUser != null)
            {
                return null;
            }
            var salt = _cryptoService.CreateSalt();
            var hashedPwd = _cryptoService.HashPassword(password, salt);
            var user = new User()
            {
                Email = username,
                Salt = salt,
                HashedPassword = hashedPwd
            };
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            if (!_userRepository.Exist(u => u.Id == user.Id))
            {
                return null;
            }
            _userRepository.UpdateUser(user);
            _userRepository.SaveChanges();
            return user;
        }


        public IEnumerable<User> GetTotalUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserDetails(int id)
        {
            return _userRepository.GetById(id);
        }

        public User ValidateUser(string username, string password)
        {
            var user = _userRepository.GetUserByUserName(username);
            if (user == null)
            {
                return null;
            }
            var hashedPwd = _cryptoService.HashPassword(password, user.Salt);
            if (hashedPwd == user.HashedPassword)
            {
                return user;
            }
            return null;
        }
        public IEnumerable<User> GetUserPagination(int index = 1, int pageSize = 20, string filter = "")
        {
            return _userRepository.GetUserPagination(index, pageSize, filter);
        }
        public int GetAllUsers(string filter = "")
        {
            return _userRepository.GetAllUsers(filter);
        }
        

        #endregion

        #region all favorite movies / all purchased movies
        public IEnumerable<Favorite> AllFavoritedMovies(int userId)
        {
            if (!_userRepository.IsUserExist(userId))
            {
                return null;
            }
            return _userRepository.AllFavoritedMovies(userId);
        }

        public IEnumerable<Favorite> AllFavoritedMovies(string username)
        {
            if (!_userRepository.IsUserExist(username))
            {
                return null;
            }
            return _userRepository.AllFavoritedMovies(username);
        }

        public IEnumerable<Purchase> AllPurchasedMovies(int userId)
        {

            if (!_userRepository.IsUserExist(userId))
            {
                return null;
            }
            return _userRepository.AllPurchasedMovies(userId);
        }

        public IEnumerable<Purchase> AllPurchasedMovies(string username)
        {

            if (!_userRepository.IsUserExist(username) )
            {
                return null;
            }
            return _userRepository.AllPurchasedMovies(username);
        }
        #endregion

        #region ismoviefavorite / ismoviepurchased / isaddreview
        public bool IsMovieFavorited(int userId, int movieId)
        {
            if (!_userRepository.IsUserExist(userId) || !_userRepository.IsMovieExist(movieId))
            {
                return false;
            }
            return _userRepository.IsMovieFavorited(userId, movieId);
        }

        public bool IsMoviePurchased(string username, int movieId)
        {
            if (!_userRepository.IsUserExist(username) ||!_userRepository.IsMovieExist(movieId))
            {
                return false;
            }
            return _userRepository.IsMoviePurchased(username, movieId);
        }

        public bool IsMoviePurchased(int userId, int movieId)
        {
            return _userRepository.IsMoviePurchased(userId, movieId);
        }

        public bool IsMovieFavorited(string usename, int movieId)
        {
            if (!_userRepository.IsUserExist(usename) || !_userRepository.IsMovieExist(movieId))
            {
                return false;
            }
            return _userRepository.IsMovieFavorited(usename, movieId);
        }

        public bool IsAddReview(int userId, int movieId)
        {
            return _userRepository.IsAddReview(userId, movieId);
        }

        public bool IsAddReview(string username, int movieId)
        {
            return _userRepository.IsAddReview(username, movieId);
        }
        #endregion

        #region addmovie/ addfavorite / addreview / total price
        public Purchase AddPurchaseMovie(Purchase purchase)
        {
            if (!_userRepository.IsUserExist(purchase.UserId) 
                || !_userRepository.IsMovieExist(purchase.MovieId)
                || IsMoviePurchased(purchase.UserId, purchase.MovieId))
            {
                return null;
            }
            _userRepository.AddPurchaseMovie(purchase);
            _userRepository.SaveChanges();
            return purchase;
        }

        public Favorite AddFavoriteMovie(Favorite favorite)
        {
            if (!_userRepository.IsUserExist(favorite.UserId) 
                || !_userRepository.IsMovieExist(favorite.MovieId)
                || IsMovieFavorited(favorite.UserId,favorite.MovieId))
            {
                return null;
            }
            _userRepository.AddFavoriteMovie(favorite);
            _userRepository.SaveChanges();
            return favorite;
        }

        public Review AddReviewToMovie(Review review)
        {
            if (!_userRepository.IsUserExist(review.UserId) 
                || !_userRepository.IsMovieExist(review.MovieId)
                || _userRepository.IsAddReview(review.UserId,review.MovieId))
            {
                return null;
            }
            _userRepository.AddReviewToMovie(review);
            _userRepository.SaveChanges();
            return review;
        }

        public decimal GetTotalPrice(int movieId)
        {
            return _userRepository.GetTotalPrice(movieId) ?? 0;
        }
        #endregion

        #region update review
        public Review UpdateReview(Review review)
        {
            if (!_userRepository.IsUserExist(review.UserId)
                || _userRepository.IsAddReview(review.UserId, review.MovieId))
            {
                return null;
            }
            _userRepository.UpdateReview(review);
            _userRepository.SaveChanges();
            return review;
        }

        public IEnumerable<Review> GetUserReviews(int userId)
        {
            return _userRepository.GetUserReviews(userId);
        }

        public IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO)
        {
            return _userRepository.GetAllPurchasedUser(pageDTO);
        }

        public IEnumerable<Purchase> AllPurchasedMovies(PageDTO pageDTO)
        {
            return _userRepository.GetAllPurchasedMovies(pageDTO);
        }

        public IEnumerable<Purchase> GetAllPurchasesForMovie(PageDTO pageDTO)
        {
            return _userRepository.GetAllPurchaseForMovie(pageDTO);
        }

        public IEnumerable<User> GetAllUsers(PageDTO pageDTO)
        {
            return _userRepository.GetUserPagination(pageDTO.Index,pageDTO.PageSize,pageDTO.Filter);
        }

        protected override void SetCurrentRepository()
        {
            base.repository=_userRepository;
        }

        public int TotalPurchaseRecords(Expression<Func<Purchase, bool>> whereCondition)
        {
            return _userRepository.TotalPurchaseRecords(whereCondition);
        }
        #endregion
    }
}
