using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Repositories;
using System.Threading.Tasks;

namespace RealEstateScrapper.DataAccess.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly RealEstateContext _context;
        public CityRepository(RealEstateContext context) : base(context) { }
        public async Task<City> GetCityDetails(string cityName)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Name.ToLower() == cityName.ToLower());
            return city;
        }
    }
}
