using MovieStore.Data.RepositoryInterfaces;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class RatingDTO: IRatingDTO
    {
        public Movie movie { get; set; }
        public decimal rating { get; set; }
    }
}
