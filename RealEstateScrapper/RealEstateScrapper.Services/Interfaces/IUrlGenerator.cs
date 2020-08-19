using RealEstateScrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IUrlGenerator<T> where T : ITargetWebsite
    {
        public string GenerateUrl(City city);
    }
}
