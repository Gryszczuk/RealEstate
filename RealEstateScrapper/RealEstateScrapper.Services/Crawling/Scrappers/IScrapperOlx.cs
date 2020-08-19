using RealEstateScrapper.Services.Interfaces;
using RealEstateScrapper.Services.Scrappings.Webistes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Crawling.Scrappers
{
    public class IScrapperOlx : IScrapper<OlxTargetWebsite>
    {
        public int GetPagesCount()
        {
            throw new NotImplementedException();
        }
    }
}
