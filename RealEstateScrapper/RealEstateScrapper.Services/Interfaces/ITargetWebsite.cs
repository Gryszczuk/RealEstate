using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface ITargetWebsite
    {
        public string Name { get; }
        public string DocumentNodeXPath { get; }
        public string PagesCountXPath { get; }
    }
}
