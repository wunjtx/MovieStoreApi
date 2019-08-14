using Dapper;
using MovieStore.Dapper.Services.Interface;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Dapper.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IDbConntectionFactory _dbConntectionFactory;
        public MovieService(IDbConntectionFactory dbConntectionFactory)
        {
            _dbConntectionFactory = dbConntectionFactory;
        }
        public Movie AddMovie(Movie movie)
        {
            using (IDbConnection conn = _dbConntectionFactory.GetConnection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", movie.Id, DbType.Int32);
                p.Add("@Title", movie.Title, DbType.String);
                p.Add("@Overview", movie.Overview, DbType.String);
                p.Add("@Tagline", movie.Tagline, DbType.String);
                p.Add("@Budget", movie.Budget);
                p.Add("@Revenue", movie.Revenue);
                p.Add("@ImdbUrl", movie.ImdbUrl);
                p.Add("@PosterUrl", movie.PosterUrl);
                p.Add("@BackdropUrl", movie.BackdropUrl);
                p.Add("@OriginalLanguage", movie.OriginalLanguage);
                p.Add("@ReleaseDate", movie.ReleaseDate);
                p.Add("@RunTime", movie.RunTime);
                p.Add("@Price", movie.Price);
                string sql = @"Insert into Movie (Title, Overview,Tagline,Budget,Revenue,ImdbUrl,PosterUrl,BackdropUrl,OriginalLanguage,ReleaseDate,RunTime,Price) OUTPUT INSERTED.[Id] values (@Title, @Overview,@Tagline,@Budget,@Revenue,@ImdbUrl,@PosterUrl,@BackdropUrl,@OriginalLanguage,@ReleaseDate,@RunTime,@Price)";
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        //int updatedId = conn.Execute(sql, p, trans);
                        var updatedId = conn.QuerySingle<int>(sql, p, trans);

                        trans.Commit();
                        return GetMovieById(updatedId);
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return null;
                    }
                    finally
                    {
                        conn.Dispose();
                    }
                }
            }
        }

        public IEnumerable<Movie> GetAllMovies(PageDTO page)
        {
            //using(var conn = _dbConntectionFactory.GetConnection)
            //{
            //    string sql = "";
            //    if ( string.IsNullOrWhiteSpace(page.Filter))
            //    {
            //        sql += "select * from Movie ";
            //    }
            //    else
            //    {
            //        sql += "select * from Movie where title like '@title" + "%'" ;
            //    }

            //    sql += " ORDER BY id OFFSET @PageSize * (@PageIndex - 1) ROWS FETCH NEXT @PageSize ROWS ONLY";

            //    var par = new DynamicParameters();
            //    par.Add("@PageSize", page.PageSize);
            //    par.Add("@PageIndex", page.Index);
            //    par.Add("@title", page.Filter);

            //    var res = await conn.QueryAsync<Movie>(sql, par);
            //    return res;
            //}
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(PageDTO page)
        {
            using (var conn = _dbConntectionFactory.GetConnection)
            {
                string sql = "";
                var par = new DynamicParameters();
                if (string.IsNullOrWhiteSpace(page.Filter))
                {
                    sql += "select * from Movie ";
                    par.Add("@PageSize", page.PageSize);
                    par.Add("@PageIndex", page.Index);
                }
                else
                {
                    sql += "select * from Movie where title like @title ";
                    par.Add("@PageSize", page.PageSize);
                    par.Add("@PageIndex", page.Index);
                    par.Add("@title", page.Filter + "%");
                }

                sql += " ORDER BY id OFFSET @PageSize * (@PageIndex - 1) ROWS FETCH NEXT @PageSize ROWS ONLY";

                //string str = "select * from Movie where title like 'a%' ORDER BY id OFFSET 0 rows fetch next 20 rows only";
                //var res1 = await conn.QueryAsync<Movie>(str);
                var res = await conn.QueryAsync<Movie>(sql, par);
                return res;
            }
        }


        public Movie GetMovieById(int id)
        {
            using (var conn = _dbConntectionFactory.GetConnection)
            {
                string sql = "select * from Movie where id =@id";

                var p = new DynamicParameters();
                p.Add("@id", id);

                var movie = conn.QuerySingle<Movie>(sql, p);
                return movie;
            }
        }

        public IEnumerable<Movie> GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByPagination(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesCarousel(string title = "", int count = 6)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopGrossingMovies(int count = 20)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RatingDTO> GetTopRatedMovies(int page = 1, int pageSize = 20, string titleFilter = "")
        {
            throw new NotImplementedException();
        }

        public int GetTotalMovies(string name = "")
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable< Purchase>> GetPurchasedMovies(int customerId)
        {
            using (var conn = _dbConntectionFactory.GetConnection)
            {
                string sql = "select u.*,p.*,m.* from [User] u left join Purchase p on u.Id = p.UserId left join Movie m on p.MovieId = m.Id where u.Id=@Id";
                var par = new DynamicParameters();
                par.Add("@Id", customerId);
                //this is for select * ; select *
                //List<User> userList = null;
                //List<Movie> movieList = null;
                //List<Purchase> purchaseList = null;
                //using (var res = conn.QueryMultiple(sql, par))
                //{
                //    userList = res.Read<User>().ToList();
                //    movieList = res.Read<Movie>().ToList();
                //    purchaseList = res.Read<Purchase>().ToList();
                //}
                var res = await conn.QueryAsync< User, Purchase, Movie, Purchase >(sql, (user,  purchase, movie) =>
                      {
                          purchase.Movie = movie;
                          purchase.Customer = user;
                          return purchase;
                      }
                ,par);
                return res;
            }
        }

        public Movie UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            using(var conn = _dbConntectionFactory.GetConnection)
            {
                string sql = "update Movie set Title=@Title,Overview=@Overview where id = @Id";
                var par = new DynamicParameters();
                par.Add("@Id", movie.Id);
                par.Add("@Title", movie.Title);
                par.Add("@Overview", movie.Overview);

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        //await conn.ExecuteAsync("update Movie set Title = 'test1', Overview = 'test1' where id = 1201");
                        await conn.ExecuteAsync(sql,par,trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }
    }
}
