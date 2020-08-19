using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Scrappings.Webistes;

namespace RealEstateScrapper.Services.Crawling.UrlGenerators
{
    public class OlxUrlGenerator : IUrlGenerator<OlxTargetWebsite>
    {
        public string GeneratePageUrl(City city, int pageNumber)
        {
           return  $"https://www.olx.pl/nieruchomosci/mieszkania/sprzedaz/olsztyn/?page={pageNumber}";
        }
    }
}
