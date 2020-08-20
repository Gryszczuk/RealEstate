using HtmlAgilityPack;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public abstract class BaseScrapper<TWebsite> : IScrappingService where TWebsite : ITargetWebsite, new()
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
        public virtual async Task CollectData(City city)
        {
            for (int i = 0; i < await GetPagesCount(); i++)
            {
                var url = _urlGenerator.GeneratePageUrl(city, i);
                var htmlDoc = await HtmlClient.LoadFromWebAsync(url);
                var nodes = htmlDoc.DocumentNode
                   .SelectNodes(TargetWebsite.DocumentNodeXPath).ToList();

                var offers = GetDetails(nodes);
                await _repository.AddMany(offers);
                //todo find better anti-ban solution
                Thread.Sleep(4000);
            }
        }
        protected virtual async Task<int> GetPagesCount()
        {
            var url = _urlGenerator.GeneratePageUrl(CurrentCity, 1);
            var htmlDoc = await HtmlClient.LoadFromWebAsync(url);
            HtmlNode pageCount = htmlDoc.DocumentNode.SelectSingleNode(TargetWebsite.PagesCountXPath);
            return Convert.ToInt32(pageCount.InnerHtml);
        }
        protected abstract List<Offer> GetDetails(List<HtmlNode> nodes);
    }
}
