using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Helpers;
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
        public async Task<PagedList<Offer>> GetOffers(City city, QueryArgs query)
        {
            var offers = await _context.Offers.Where(offer => offer.City == city
            && offer.Price >= query.MinPrice
            && offer.Price <= query.MaxPrice
            && offer.IsActive)
                .GetPaged(query.Page, query.PageSize);
            return offers;
        }
        public async Task<PagedList<Offer>> GetOffers(QueryArgs query)
        {
            var offers = await _context.Offers.Where(offer => offer.Price >= query.MinPrice
           && offer.Price <= query.MaxPrice
           && offer.IsActive)
             .GetPaged(query.Page, query.PageSize);

            return offers;
        }
    }
}
