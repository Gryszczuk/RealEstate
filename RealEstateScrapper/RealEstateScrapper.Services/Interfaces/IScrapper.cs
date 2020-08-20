using HtmlAgilityPack;
using RealEstateScrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IScrappingService
    {
        public Task CollectData(City city);
    }
}
