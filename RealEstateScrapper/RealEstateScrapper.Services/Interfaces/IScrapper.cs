using HtmlAgilityPack;
using RealEstateScrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IScrapper<T> where T : ITargetWebsite
    {
        public City CurrentCity { get; set; }
        public Task CollectData();
        public int GetPagesCount();
        public List<Offer> GetDetails(List<HtmlNode> nodes);
    }
}
