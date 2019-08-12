using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.RepositoryInterfaces
{
    public interface IRatingDTO
    {
        Movie movie { get; set; }
        decimal rating { get; set; }
    }
}
