using RealEstateScrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Scrappings.Webistes
{
    public class OlxTargetWebsite : ITargetWebsite
    {
        public string Name { get { return "olx"; } }
    }
}
