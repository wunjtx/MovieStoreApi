using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class PageDTO
    {
        [Range(typeof(int),"0","200")]
        public int Index { get; set; } = 1;
        [Range(10,50)]
        public int PageSize { get; set; } = 20;
        [StringLength(32)]
        public string Filter { get; set; } = "";
        public int id { get; set; }
    }
}
