using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
