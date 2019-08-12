using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.DTO
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Overview { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
    }
}
