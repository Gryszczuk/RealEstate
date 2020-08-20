using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Statistics
{
    public class StatisticService : IStatisticsService
    {
        private readonly IOfferRepository _repository;
        public StatisticService(IOfferRepository repository)
        {
            _repository = repository;
        }
        public async Task CalculateStatistics(City city)
        {
            var averagePrice = _repository.
            var snapshot = new StatisticsSnapshot
            {
                AveragePrice
            }
        }
    }
}
