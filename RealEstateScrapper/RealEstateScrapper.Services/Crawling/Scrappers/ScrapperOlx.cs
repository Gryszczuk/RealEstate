using HtmlAgilityPack;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Helpers;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Repositories;
using RealEstateScrapper.Services.Scrappings.Webistes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public class ScrapperOlx : BaseScrapper<OlxTargetWebsite>, IScrappingService
    {
        public ScrapperOlx(IUrlGenerator<OlxTargetWebsite> urlGenerator,
            IOfferRepository repository) : base(urlGenerator, repository) { }
       
        public async Task CollectData(City city)
        {
            for (int i = 0; i < GetPagesCount(); i++)
            {
                var url = _urlGenerator.GeneratePageUrl(city, i);
                var htmlDoc = await HtmlClient.LoadFromWebAsync(url);
                var nodes = htmlDoc.DocumentNode
                   .SelectNodes("//table[@id='offers_table']/tbody/tr[@class='wrap']/td").ToList();
               
                var offers = GetDetails(nodes);
                await _repository.AddMany(offers);
            }
        }

        protected int GetPagesCount()
        {
            var url = _urlGenerator.GeneratePageUrl(CurrentCity, 1);
            var htmlDoc = HtmlClient.Load(url);
            HtmlNode pageCount = htmlDoc.DocumentNode.SelectSingleNode("//a[@data-cy='page-link-last']/span");
            return Convert.ToInt32(pageCount.InnerHtml);
        }
        protected List<Offer> GetDetails(List<HtmlNode> nodes)
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
                offers.Add(offer);
            }
            return offers;
        }
    }
}
