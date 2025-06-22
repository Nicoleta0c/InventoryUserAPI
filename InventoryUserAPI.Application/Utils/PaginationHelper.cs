using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryUserAPI.Application.Utils
{
    public static class PaginationHelper
    {
        public static IEnumerable<T> Paginate<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static int GetTotalPages(int totalItems, int pageSize)
        {
            if (pageSize <= 0) return 1;
            return (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
