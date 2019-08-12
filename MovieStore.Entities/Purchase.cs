using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User Customer { get; set; }
    }
}
