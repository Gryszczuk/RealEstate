using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Helpers;
using RealEstateScrapper.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Repositories
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<PagedList<Offer>> GetOffers(City city, QueryArgs args);
        Task<PagedList<Offer>> GetOffers(QueryArgs args);
    }
}
