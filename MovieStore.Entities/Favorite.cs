using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class Favorite
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
