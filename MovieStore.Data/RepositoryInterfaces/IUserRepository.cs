using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface IUserRepository:IRepository<User>
    {
        //IEnumerable<Movie> GetMoviesByGenre(int genreId);
        User GetUserByUserName(string username);
        User GetUserDetails(int id);
        Purchase AddPurchaseMovie(Purchase purchase);
        Favorite AddFavoriteMovie(Favorite favorite);
        IEnumerable<Purchase> AllPurchasedMovies(int userId);
        IEnumerable<Favorite> AllFavoritedMovies(int userId);
        IEnumerable<Purchase> AllPurchasedMovies(string username);
        IEnumerable<Favorite> AllFavoritedMovies(string username);
        bool IsMoviePurchased(int userId, int movieId);
        bool IsMoviePurchased(string username, int movieId);
        bool IsMovieFavorited(int userId, int movieId);
        bool IsMovieFavorited(string username, int movieId);
        bool IsUserExist(int userId);
        bool IsUserExist(string username);
        bool IsMovieExist(int movieId);
        int GetAllUsers(string filter = "");
        IEnumerable<User> GetUserPagination(int index = 1, int pageSize = 20, string filter = "");
        Review AddReviewToMovie(Review review);
        decimal? GetTotalPrice(int movieId);
        IEnumerable<Review> GetUserReviews(int userId);
        bool IsAddReview(int userId, int movieId);
        bool IsAddReview(string username, int movieId);
        User UpdateUser(User user);
        Review UpdateReview(Review review);
        int TotalPurchaseRecords(Expression<Func<Purchase, bool>> whereCondition);
        IEnumerable<User> GetAllPurchasedUser(PageDTO pageDTO);
        IEnumerable<Purchase> GetAllPurchasedMovies(PageDTO pageDTO);
        IEnumerable<Purchase> GetAllPurchaseForMovie(PageDTO pageDTO);
    }
}
