using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Repositories
{
    public interface IOfferRepository : IRepository<Offer>
    {
        Task<IEnumerable<Offer>> GetOffersInCity(City city);
    }
}
