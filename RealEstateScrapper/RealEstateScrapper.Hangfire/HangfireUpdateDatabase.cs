using RealEstateScrapper.Hangfire.Interfaces;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using RealEstateScrapper.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Hangfire
{
    public class HangfireUpdateDatabase : IHangfireUpdateDatabase
    {
        private IEnumerable<IScrappingService> _scrapers;
        private ICityRepository _cityRepository;
        private IStatisticsService _statistics;
        public HangfireUpdateDatabase(IEnumerable<IScrappingService> scrappers,
            ICityRepository cityRepository,
            IStatisticsService statistics
            )
        {
            _scrapers = scrappers;
            _cityRepository = cityRepository;
            _statistics = statistics;
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
                await _statistics.CalculateStatistics(city);
            }
        }
    }
}
