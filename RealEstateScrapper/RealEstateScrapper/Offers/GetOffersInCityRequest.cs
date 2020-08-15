namespace RealEstateScrapper.Offers
{
    public class GetOffersInCityRequest
    {
        public string City { get; set; }
        public decimal MinimalPrice { get; set; }
        public decimal MaximumPrice { get; set; }
    }
}
