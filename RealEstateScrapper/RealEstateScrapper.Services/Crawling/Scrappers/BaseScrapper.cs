using HtmlAgilityPack;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public abstract class BaseScrapper<TWebsite> where TWebsite : ITargetWebsite, new()
    {
        protected readonly IUrlGenerator<TWebsite> _urlGenerator;
        protected readonly IOfferRepository _repository;
        protected TWebsite TargetWebsite { get; }

        protected  HtmlWeb HtmlClient{ get; }
        protected City CurrentCity { get; set;
        }
        public BaseScrapper(IUrlGenerator<TWebsite> urlGenerator,
            IOfferRepository repository)
        {
            _urlGenerator = urlGenerator;
            _repository = repository;
            HtmlClient = new HtmlWeb();
            TargetWebsite = new TWebsite();
        }
        protected virtual async Task CollectData(City city)
        {
            for (int i = 0; i < GetPagesCount(); i++)
            {
                var url = _urlGenerator.GeneratePageUrl(city, i);
                var htmlDoc = await HtmlClient.LoadFromWebAsync(url);
                var nodes = htmlDoc.DocumentNode
                   .SelectNodes(TargetWebsite.DocumentNodeXPath).ToList();

                var offers = GetDetails(nodes);
                await _repository.AddMany(offers);
            }
        }
        protected virtual async Task<int> GetPagesCount()
        {
            var url = _urlGenerator.GeneratePageUrl(CurrentCity, 1);
            var htmlDoc = await Html
        }
    }
}
