using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsService(IOfferRepository offerRepository,
            IStatisticsRepository statisticsRepository)
        {
            _offerRepository = offerRepository;
            _statisticsRepository = statisticsRepository;
        }
        public async Task CalculateStatistics(City city)
        {
            var averagePrice = await _offerRepository.GetAveragePriceForCity(city);
            var count = await _offerRepository.GetOffersCountForCity(city);

            var snapshot = new StatisticsSnapshot
            {
                AveragePrice = averagePrice,
                Count = count,
                DateCreated = DateTime.UtcNow,
                City = city
            };
            await _statisticsRepository.Add(snapshot);
        }
    }
}
