using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Dapper.Services.Interface
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
    }
}
