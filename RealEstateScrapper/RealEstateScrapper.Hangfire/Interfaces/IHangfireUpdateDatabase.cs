using System.Threading.Tasks;

namespace RealEstateScrapper.Hangfire.Interfaces
{
    public interface IHangfireUpdateDatabase
    {
        Task Update();
    }
}
