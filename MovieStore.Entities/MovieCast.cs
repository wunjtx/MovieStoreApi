using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class MovieCast
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
    }
}
