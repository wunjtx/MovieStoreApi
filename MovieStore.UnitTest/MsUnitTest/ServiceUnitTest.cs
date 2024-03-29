﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using MovieStore.Services.ServiceImplementations;
using MovieStore.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieStore.UnitTest
{
    [TestClass]
    public class ServiceUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ct = _movieService.GetTotalMovies("t1");
            //_mockMovieRepository.Verify(p => p.GetTotalRecords(m=>m.Title=="t1"), Times.Once);
            //Assert.AreEqual(3, ct);
            Assert.AreEqual(3, ct);
        }

        private Mock<IMovieRepository> _mockMovieRepository = new Mock<IMovieRepository>();
        private IMovieService _movieService;
        private List<Movie> movies;

        [TestInitialize]
        public void Initialize()
        {
            movies = new List<Movie>()
            {
                new Movie(){Id=1,Title="t1",Overview="o1" },
                new Movie(){Id=2,Title="t1",Overview="o2" },
                new Movie(){Id=3,Title="t1",Overview="o3" },
                new Movie(){Id=4,Title="t4",Overview="o4" },
                new Movie(){Id=5,Title="t5",Overview="o5" },
                new Movie(){Id=6,Title="t6",Overview="o6" },
                new Movie(){Id=7,Title="t7",Overview="o7" },
                new Movie(){Id=8,Title="t8",Overview="o8" },
            };
            //_mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object);

            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => { return movies.Single(c => c.Id == id); });
            _mockMovieRepository.Setup(m => m.Update(It.IsAny<Movie>())).Returns((Movie movie) => movie);
            _mockMovieRepository.Setup(m => m.GetByWhere(It.IsAny<Expression<Func<Movie, bool>>>()))
                .Returns<Expression<Func<Movie, bool>>>((expression) =>
                {
                    return movies.AsQueryable().Where(expression).ToList();
                });
            _mockMovieRepository.Setup(m => m.GetTotalRecords(It.IsAny<Expression<Func<Movie, bool>>>()))
               .Returns((Expression<Func<Movie, bool>> expression) =>
               {
                   return movies.AsQueryable().Where(expression).ToList().Count;
               });

            //_mockMovieRepository.Setup(m => m.GetTotalRecords(It.IsAny<Expression<Func<Movie, bool>>>()))
            //    .Returns((Expression<Func<Movie, bool>> expression) =>
            //    {
            //        return movies.AsQueryable().Where(expression.Compile()).ToList().Count;
            //    });
            //_mockMovieRepository.Setup(m => m.GetTotalRecords(It.IsAny<Expression<Func<Movie, bool>>>()))
            //    .Returns((Expression<Func<Movie, bool>> expression) =>
            //    {
            //        return movies.AsQueryable().Where(expression).ToList().Count;
            //    });
            //_mockMovieRepository.Setup(m => m.GetTotalRecords(c => c.Title == It.IsAny<string>()))
            //    .Returns((Expression<Func<Movie, bool>> expression) =>
            //    {
            //        return movies.AsQueryable().Where(expression).ToList().Count;
            //    });
        }

        [TestMethod]
        public void GetById()
        {
            var movie = _movieService.GetMovieById(1);
            Assert.AreEqual(1, movie.Id);
        }
    }
}
