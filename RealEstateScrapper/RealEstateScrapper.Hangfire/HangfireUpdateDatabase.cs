using RealEstateScrapper.Hangfire.Interfaces;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Hangfire
{
    public class HangfireUpdateDatabase : IHangfireUpdateDatabase
    {
        private IEnumerable<IScrappingService> _scrapers;
        private ICityRepository _cityRepository;
        public HangfireUpdateDatabase(IEnumerable<IScrappingService> scrappers,
            ICityRepository cityRepository)
        {
            _scrapers = scrappers;
            _cityRepository = cityRepository;
        }
        public async Task Update()
        {
            var cities = await _cityRepository.GetAll();
            foreach (var city in cities)
            {
                await _scrapers.AsyncParallelForEach(async scrapper =>
                {
                    await scrapper.CollectData(city);
                });
            }
        }
    }
}
