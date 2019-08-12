using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.DTO
{
    public class PurchaseDetailsDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Overview { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public string UseName { get; set; }
        public DateTime PurchaseDateTime { get; set; }
    }
}
