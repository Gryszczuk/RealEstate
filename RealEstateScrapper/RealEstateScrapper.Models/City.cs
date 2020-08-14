using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Models
{
    public class City
    {
        public string Name { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
