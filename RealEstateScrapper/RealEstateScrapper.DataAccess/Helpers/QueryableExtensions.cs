using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Helpers;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> GetPaged<T>(this IQueryable<T> query,
            int page, int pageSize) where T : BaseModel
        {
            return await PagedList<T>.Create(query, page, pageSize);
        }  
    }
}
