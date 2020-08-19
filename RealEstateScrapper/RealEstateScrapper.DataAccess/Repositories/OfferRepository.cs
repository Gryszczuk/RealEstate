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
        public OfferRepository(RealEstateContext context) : base(context) { }
        public async Task<PagedList<Offer>> GetOffers(City city, QueryArgs query)
        {
            //var offers =  _context.Offers.Where(offer => offer.City == city
            //&& offer.Price >= query.MinPrice
            //&& offer.Price <= query.MaxPrice
            //&& offer.IsActive)
            //    .GetPaged(query.Page, query.PageSize);
            //return await offers.ToListAsync();
            throw new NotImplementedException();
        }
        public async Task<PagedList<Offer>> GetOffers(QueryArgs query)
        {
            var offersQuery = _context.Offers.Where(offer => offer.Price >= query.MinPrice
          && offer.Price <= query.MaxPrice
          && offer.IsActive);
           var offers = await offersQuery
             .GetPaged(query.Page, query.PageSize)
             .ToListAsync();
            var totalCount = offers.Count;
            var temp = PagedList<Offer>.Create(offers, query.Page, query.PageSize, totalCount);
            return temp;
        }
    }
}
