using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MovieStore.Data.RepositoryImplementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieStoreDbContext movieStoreDbContext) : base(movieStoreDbContext)
        {
        }

        public Purchase AddPurchaseMovie(Purchase purchase)
        {
            _movieStoreDbContext.Entry(purchase).State = EntityState.Added;
            return purchase;
        }

        public Favorite AddFavoriteMovie(Favorite favorite)
        {
            _movieStoreDbContext.Entry(favorite).State = EntityState.Added;
            return favorite;
        }

        public IEnumerable<Favorite> AllFavoritedMovies(int userId)
        {
            return _movieStoreDbContext.Favorites.Include(p => p.Movie).Where(f => f.UserId == userId).ToList();
        }

        public IEnumerable<Purchase> AllPurchasedMovies(int userId)
        {
            return _movieStoreDbContext.Purchases.Include(p => p.Movie).Where(m => m.UserId == userId).ToList();
        }

        public User GetUserByUserName(string username)
        {
            return _movieStoreDbContext.Users.FirstOrDefault(u => u.Email == username);
        }

        public User GetUserDetails(int id)
        {
            return _movieStoreDbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool IsMovieFavorited(int userId, int movieId)
        {
            return _movieStoreDbContext.Favorites.Any(p => p.UserId == userId && p.MovieId == movieId);
        }
        public bool IsMovieFavorited(string username, int movieId)
        {
            return _movieStoreDbContext.Favorites.Any(p => p.User.Email == username && p.MovieId == movieId);
        }

        public bool IsMoviePurchased(int userId, int movieId)
        {
            return _movieStoreDbContext.Purchases.Any(p => p.UserId == userId && p.MovieId == movieId);
        }

        public bool IsUserExist(int userId)
        {
            return Exist(u => u.Id == userId);
        }

        public bool IsMovieExist(int movieId)
        {
            return _movieStoreDbContext.Movies.Any(m => m.Id == movieId);
        }

        public IEnumerable<User> GetUserPagination(int index = 1, int pageSize = 20, string filter = "")
        {
            var query = _movieStoreDbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(u => u.FirstName.Contains(filter) || u.LastName.Contains(filter));
            }
            return query.OrderBy(o => o.LastName).Skip((index - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetAllUsers(string filter = "")
        {
            return !string.IsNullOrEmpty(filter) ? _movieStoreDbContext.Users.Where(u => u.FirstName.Contains(filter) || u.LastName.Contains(filter)).ToList().Count() : _movieStoreDbContext.Users.ToList().Count();
        }

        public IEnumerable<Review> GetUserReviews(int userId)
        {
            return _movieStoreDbContext.Reviews.Include(r => r.Movie).Include(r => r.User).Where(r => r.UserId == userId).ToList();
        }

        public Review AddReviewToMovie(Review review)
        {
            _movieStoreDbContext.Entry(review).State = EntityState.Added;
            return review;
        }

        public decimal? GetTotalPrice(int movieId)
        {
            return _movieStoreDbContext.Movies.FirstOrDefault(m => m.Id == movieId)?.Price;
        }

        public bool IsAddReview(int userId, int movieId)
        {
            return _movieStoreDbContext.Reviews.Any(r => r.MovieId == movieId && r.UserId == userId);
        }
        public bool IsAddReview(string username, int movieId)
        {
            return _movieStoreDbContext.Reviews.Any(r => r.MovieId == movieId && r.User.Email == username);
        }

        public User UpdateUser(User user)
        {
            _movieStoreDbContext.Entry(user).State = EntityState.Modified;
            return user;
        }

        public Review UpdateReview(Review review)
        {
            _movieStoreDbContext.Entry(review).State = EntityState.Modified;
            return review;
        }

        public bool IsMoviePurchased(string username, int movieId)
        {
            return _movieStoreDbContext.Purchases.Any(p => p.Customer.Email == username && p.MovieId == movieId);
        }

        public bool IsUserExist(string username)
        {
            return Exist(e => e.Email == username);
        }

        public IEnumerable<Purchase> AllPurchasedMovies(string username)
        {
            return _movieStoreDbContext.Purchases.Where(p => p.Customer.Email == username).ToList();
        }

        public IEnumerable<Favorite> AllFavoritedMovies(string username)
        {
            return _movieStoreDbContext.Favorites.Where(f => f.User.Email == username).ToList();
        }

        public int TotalPurchaseRecords(Expression<Func<Purchase, bool>> whereCondition)
        {
            return _movieStoreDbContext.Purchases.Where(whereCondition).ToList().Count;
        }

        public IEnumerable<User> GetAllPurchasedUser(PageDTO pageDTO)
        {
            var query = _movieStoreDbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(pageDTO.Filter))
            {
                query = query.Where(u => u.Email.Contains(pageDTO.Filter) || u.FirstName.Contains(pageDTO.Filter));
            }
            return query.OrderBy(o => o.Email).Skip((pageDTO.Index - 1) * pageDTO.PageSize).Take(pageDTO.PageSize).ToList();
        }

        public IEnumerable<Purchase> GetAllPurchasedMovies(PageDTO pageDTO)
        {
            var query = _movieStoreDbContext.Purchases.AsQueryable();
            if (!string.IsNullOrEmpty(pageDTO.Filter))
            {
                query = query.Where(u => u.Customer.Email.Contains(pageDTO.Filter));
            }
            return query.OrderBy(o => o.Movie.Title).Skip((pageDTO.Index - 1) * pageDTO.PageSize).Take(pageDTO.PageSize).ToList();
        }

        public IEnumerable<Purchase> GetAllPurchaseForMovie(PageDTO pageDTO)
        {
            var query = _movieStoreDbContext.Purchases.AsQueryable();
            int id;

            if (int.TryParse(pageDTO.Filter, out id) && id >0)
            {
                query = query.Where(u => u.MovieId == id);
            }

            else if (!string.IsNullOrEmpty(pageDTO.Filter))
            {
                query = query.Where(u => u.Movie.Title.Contains(pageDTO.Filter));
            }

            return query.OrderBy(o => o.Movie.Title).Skip((pageDTO.Index - 1) * pageDTO.PageSize).Take(pageDTO.PageSize).ToList();
        }
    }
}
