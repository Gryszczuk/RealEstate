using HtmlAgilityPack;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Scrappings.Webistes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public class ScrapperOlx : IScrapper<OlxTargetWebsite>
    {
        private readonly IUrlGenerator<OlxTargetWebsite> _urlGenerator;
        public City CurrentCity { get; set; }
        public HtmlWeb HtmlClient { get; }
        public ScrapperOlx(IUrlGenerator<OlxTargetWebsite> urlGenerator)
        {
            _urlGenerator = urlGenerator;
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
    }
}
