using AutoMapper;
using MovieStore.Data;
using MovieStore.Data.RepositoryImplementations;
using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStoreApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Infrastructure.Automapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<MovieDetailDTO, Movie>();
            CreateMap<Movie, MovieDetailDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Favorite, FavoriteDTO>();
            CreateMap<FavoriteDTO, Favorite>();
            CreateMap<Review, ReviewDTO>()
                .ForMember(r => r.MovieTitle, rt => rt.MapFrom(src => src.Movie.Title))
                .ForMember(r => r.UserName, rt => rt.MapFrom(src => src.User.Email));
            CreateMap<ReviewDTO, Review>()
                .ForPath(r => r.Movie.Title, rt => rt.MapFrom(src => src.MovieTitle))
                .ForPath(r => r.User.Email, rt => rt.MapFrom(src => src.UserName));
            CreateMap<Purchase, MovieDTO>()
                .ForMember(p => p.MovieId, m => m.MapFrom(src => src.MovieId))
                .ForMember(p => p.Overview, m => m.MapFrom(src => src.Movie.Overview))
                .ForMember(p => p.PosterUrl, m => m.MapFrom(src => src.Movie.PosterUrl))
                .ForMember(p => p.TotalPrice, m => m.MapFrom(src => src.TotalPrice))
                .ForMember(p => p.Title, m => m.MapFrom(src => src.Movie.Title))
                .ForMember(p => p.UserId, m => m.MapFrom(src => src.UserId));
            CreateMap<Favorite, MovieDTO>()
                .ForMember(p => p.MovieId, m => m.MapFrom(src => src.MovieId))
                .ForMember(p => p.Overview, m => m.MapFrom(src => src.Movie.Overview))
                .ForMember(p => p.PosterUrl, m => m.MapFrom(src => src.Movie.PosterUrl))
                .ForMember(p => p.TotalPrice, m => m.MapFrom(src => src.Movie.Price))
                .ForMember(p => p.Title, m => m.MapFrom(src => src.Movie.Title))
                .ForMember(p => p.UserId, m => m.MapFrom(src => src.UserId));
            CreateMap<Crew, CrewDTO>()
                .ForMember(c => c.Id, ct => ct.MapFrom(src => src.Id))
                .ForMember(c => c.Name, ct => ct.MapFrom(src => src.Name))
                .ForMember(c => c.ProfilePath, ct => ct.MapFrom(src => src.ProfilePath))
                .ForMember(c => c.TmdbUrl, ct => ct.MapFrom(src => src.TmdbUrl))
                .ForMember(c => c.Gender, ct => ct.MapFrom(src => src.Gender));
            CreateMap<Cast, CastDTO>()
                .ForMember(c => c.Id, ct => ct.MapFrom(src => src.Id))
                .ForMember(c => c.Gender, ct => ct.MapFrom(src => src.Gender))
                .ForMember(c => c.Name, ct => ct.MapFrom(src => src.Name))
                .ForMember(c => c.ProfilePath, ct => ct.MapFrom(src => src.ProfilePath))
                .ForMember(c => c.TmdbUrl, ct => ct.MapFrom(src => src.TmdbUrl));
            CreateMap<Genre, GenreDTO>()
                .ForMember(g => g.ID, gt => gt.MapFrom(src => src.ID))
                .ForMember(g => g.Name, gt => gt.MapFrom(src => src.Name));
            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(g => g.MovieId, gt => gt.MapFrom(src => src.MovieId))
                .ForMember(g => g.UserId, gt => gt.MapFrom(src => src.UserId))
                .ForMember(g => g.UseName, gt => gt.MapFrom(src => src.Customer.Email))
                .ForMember(g => g.PurchaseDateTime, gt => gt.MapFrom(src => src.PurchaseDateTime))
                .ForMember(g => g.PurchaseNumber, gt => gt.MapFrom(src => src.PurchaseNumber))
                .ForMember(g => g.TotalPrice, gt => gt.MapFrom(src => src.TotalPrice));
            CreateMap<PurchaseDTO, Purchase>()
                .ForMember(g => g.MovieId, gt => gt.MapFrom(src => src.MovieId))
                .ForMember(g => g.UserId, gt => gt.MapFrom(src => src.UserId))
                .ForPath(g => g.Customer.Email, gt => gt.MapFrom(src => src.UseName))
                .ForMember(g => g.PurchaseDateTime, gt => gt.MapFrom(src => src.PurchaseDateTime))
                .ForMember(g => g.PurchaseNumber, gt => gt.MapFrom(src => src.PurchaseNumber))
                .ForMember(g => g.TotalPrice, gt => gt.MapFrom(src => src.TotalPrice));

            CreateMap<dynamic, RatingDTO>();
            
            CreateMap<IRatingDTO, MovieDTO>()
                .ForMember(p => p.PosterUrl, m => m.MapFrom(src => src.movie.PosterUrl))
                .ForMember(p => p.Rating, m => m.MapFrom(src => src.rating))
                .ForMember(p => p.Overview, m => m.MapFrom(src => src.movie.Overview))
                .ForMember(p => p.Title, m => m.MapFrom(src => src.movie.Title));

            //public IEnumerable<CustomerDTO> GetCustomers()
            //{
            //    return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            //}

        }
    }
}
