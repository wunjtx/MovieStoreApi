using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.DTO
{
    public class FavoriteDTO
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
