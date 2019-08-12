using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
