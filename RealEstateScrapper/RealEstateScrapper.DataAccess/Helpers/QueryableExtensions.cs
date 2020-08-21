using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Helpers;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPaged<T>(this IQueryable<T> query,
            int page, int pageSize) where T : BaseModel
        {
            var count = query.Count();
            var items =  query.Skip((page - 1) * pageSize)
                .Take(pageSize);
            return items;
        }  
    }
}
