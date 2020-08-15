using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Offers.GetOffersInCity
{
   public class GetOffersInCityQuery
    {
        public GetOffersInCityQuery(string city)
        {
            City = city;
        }
        public string City { get; set; }
    }
}
