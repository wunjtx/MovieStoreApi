using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.DTO
{
    public class RatingDTO
    {
        public Movie movie { get; set; }
        public decimal rating { get; set; }
    }
}
