using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Offers.Requests
{
    public class GetOffersInCityRequest
    {
        public string City { get; set; }
        public decimal MinimalPrice { get; set; }
        public decimal MaximumPrice { get; set; }
    }
}
