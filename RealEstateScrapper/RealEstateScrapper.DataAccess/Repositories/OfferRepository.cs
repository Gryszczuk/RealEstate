using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateScrapper.DataAccess.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {
        private readonly RealEstateContext _context;
        public OfferRepository(RealEstateContext context) : base(context) { }
        public async Task<IEnumerable<Offer>> GetOffersInCity(City city)
        {
            var offers = await _context.Offers.Where(o => o.City == city).ToListAsync();
            return offers;
        }
    }
}
