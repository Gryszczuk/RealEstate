using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Repositories
{
   public interface ICityRepository : IRepository<City>
    {
        Task<City> GetCityDetails(string cityName);
    }
}
