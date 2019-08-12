using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApi.Utilities
{
    public class PagedResultSet<T> where T : class
    {
        public PagedResultSet(int page, int pageSize, int totalRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            Page = page;
            PageSize = pageSize;
            Data = data;
        }
        public int TotalRecords { get; }
        public int Page { get; }
        public int PageSize { get; }
        public IEnumerable<T> Data { get; }

    }
}
