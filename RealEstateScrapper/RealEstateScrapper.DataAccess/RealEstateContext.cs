using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;

namespace RealEstateScrapper.DataAccess
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) 
            : base(options)
        {
        }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
