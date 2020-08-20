using RealEstateScrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Scrappings.Webistes
{
    public class OlxTargetWebsite : ITargetWebsite
    {
        //todo make factory 
        public string Name { get { return "olx"; } }
        public string DocumentNodeXPath { get { return "//table[@id='offers_table']/tbody/tr[@class='wrap']/td"; } }
        public string PagesCountXPath { get { return "//a[@data-cy='page-link-last']/span"; } }

    }
}
