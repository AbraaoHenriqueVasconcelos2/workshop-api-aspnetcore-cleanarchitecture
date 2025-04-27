using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.pagination;
using Microsoft.EntityFrameworkCore;

namespace EventFeedbackAPI.Infra.Data.helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedList<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take((pageSize)).ToListAsync();
            //var items =   source.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take((pageSize)).ToList();
            return new PagedList<T>(items, pageNumber, pageSize, count);
        }
    }
}
