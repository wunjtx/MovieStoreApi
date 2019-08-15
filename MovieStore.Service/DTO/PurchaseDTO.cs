using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Services.DTO
{
    public class PurchaseDTO
    {
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string UseName { get; set; }
    }
}
