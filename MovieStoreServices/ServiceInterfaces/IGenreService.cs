using System;
using System.Collections.Generic;
using System.Text;
using MovieStore.Entities;

namespace MovieStore.Services.ServiceInterfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
    }
}
