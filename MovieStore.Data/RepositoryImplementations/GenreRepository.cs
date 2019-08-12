using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.RepositoryImplementations
{
    public class GenreRepository:Repository<Genre>,IGenreRepository
    {
        public GenreRepository(MovieStoreDbContext movieStoreDbContext) : base(movieStoreDbContext)
        {

        }
    }
}
