using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Scrappings.Webistes;

namespace RealEstateScrapper.Services.Crawling.UrlGenerators
{
    public class OlxUrlGenerator : IUrlGenerator<OlxTargetWebsite>
    {
        public string GeneratePageUrl(City city, int pageNumber)
        {
            var url = string.Format("https://www.olx.pl/nieruchomosci/mieszkania/sprzedaz/{0}/?page={1}", city.Name, pageNumber);
            return url;
        }
    }
}
