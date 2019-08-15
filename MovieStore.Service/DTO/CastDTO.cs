using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Services.DTO
{
    public class CastDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
    }
}
