using HtmlAgilityPack;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using RealEstateScrapper.Services.Scrappings.Webistes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public class ScrapperOlx : IScrapper<OlxTargetWebsite>
    {
        private readonly IUrlGenerator<OlxTargetWebsite> _urlGenerator;
        private readonly IOfferRepository _repository;
        public City CurrentCity { get; set; }
        private HtmlWeb HtmlClient { get; }
        public ScrapperOlx(IUrlGenerator<OlxTargetWebsite> urlGenerator,
            IOfferRepository repository)
        {
            _urlGenerator = urlGenerator;
            _repository = repository;
            HtmlClient = new HtmlWeb();
        }

        public Task CollectData()
        {
            throw new NotImplementedException();
        }

        public int GetPagesCount()
        {
            var url = _urlGenerator.GeneratePageUrl(CurrentCity, 1);
            var htmlDoc = HtmlClient.Load(url);
            HtmlNode pageCount = htmlDoc.DocumentNode.SelectSingleNode("//a[@data-cy='page-link-last']/span");
            return Convert.ToInt32(pageCount.InnerHtml);
        }
        public List<Offer> GetDetails(List<HtmlNode> nodes)
        {
            List<Offer> offers = new List<Offer>();
            foreach (var node in nodes)
            {
                string _image = string.Empty;
                var singleNode = node.SelectSingleNode(".//img[@class='fleft']");
                if (singleNode == null)
                {
                    _image = null;
                }
                else
                {
                    _image = singleNode.Attributes["src"].Value;
                }
                Offer offer = new Offer
                {
                    Image = _image,
                    Link = node.SelectSingleNode(".//a").Attributes["href"].Value,
                    City = CurrentCity,
                    Portal = "olx",
                    Price = StringToDecimalConverter.ConvertStringToDecimal(
                        node.SelectSingleNode(".//p[@class='price']/strong").InnerHtml.Replace(" ", "")),
                    Name = node.SelectSingleNode(".//strong").InnerHtml
                };
            }
        }
    }
}
