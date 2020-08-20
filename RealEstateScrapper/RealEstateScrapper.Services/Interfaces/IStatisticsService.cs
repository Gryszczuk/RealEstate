using RealEstateScrapper.Models;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task CalculateStatistics(City city);
    }
}
