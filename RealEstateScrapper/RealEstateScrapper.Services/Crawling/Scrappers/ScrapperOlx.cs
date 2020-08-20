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
    public class ScrapperOlx : BaseScrapper<OlxTargetWebsite>
    {
        public ScrapperOlx(IUrlGenerator<OlxTargetWebsite> urlGenerator,
            IOfferRepository repository) : base(urlGenerator, repository) { }
       
        protected override List<Offer> GetDetails(List<HtmlNode> nodes)
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
