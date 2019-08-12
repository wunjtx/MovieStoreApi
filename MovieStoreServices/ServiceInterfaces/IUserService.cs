using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface IUserService: IService<User>
    {
        //User GetUserDetails(int id);
        IEnumerable<User> GetTotalUsers();
        User CreateUser(string username, string password, int[] roles = null);
        User ValidateUser(string username, string password);
        User GetUserDetails(int id);
        int TotalPurchaseRecords(Expression<Func<Purchase,bool>> whereCondition);
        /*
        Purchase movie
        Favorite movie
        All movies purchased by user id
        All favorite movie by user id
        Is movie purchased for user id
        Is movie favorited for use id
        */
        IEnumerable<Purchase> AllPurchasedMovies(string username);
        IEnumerable<Favorite> AllFavoritedMovies(string username);
        IEnumerable<User> GetAllPuchasedUser(PageDTO pageDTO);
        Purchase AddPurchaseMovie(Purchase purchase);
        IEnumerable<Purchase> AllPurchasedMovies(PageDTO pageDTO);
        Favorite AddFavoriteMovie(Favorite favorite);
        IEnumerable<Purchase> AllPurchasedMovies(int userId);
        IEnumerable<Purchase> GetAllPurchasesForMovie(PageDTO pageDTO);
        IEnumerable<Favorite> AllFavoritedMovies(int userId);
        IEnumerable<User> GetAllUsers(PageDTO pageDTO);
        bool IsMoviePurchased(int userId, int movieId);
        bool IsMoviePurchased(string username, int movieId);
        bool IsMovieFavorited(int userId, int movieId);
        bool IsMovieFavorited(string username, int movieId);
        int GetAllUsers(string filter = "");
        IEnumerable<Review> GetUserReviews(int userId);
        Review AddReviewToMovie(Review review);
        decimal GetTotalPrice(int movieId);
        IEnumerable<User> GetUserPagination(int index = 1, int pageSize = 20, string filter = "");
        User UpdateUser(User user);
        Review UpdateReview(Review review);
        bool IsAddReview(string username, int movieId);
        bool IsAddReview(int userId, int movieId);
    }
}
