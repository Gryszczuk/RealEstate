using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Models.Dto
{
    public class OfferDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string City { get; set; }
        public string Portal { get; set; }
    }
}
