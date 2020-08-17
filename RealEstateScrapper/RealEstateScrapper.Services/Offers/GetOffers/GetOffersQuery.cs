using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Models.Helpers;
using RealEstateScrapper.Services.Helpers;
using System.Collections.Generic;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersQuery : IRequest<Result<List<OfferDto>>>
    {
        public GetOffersQuery(QueryArgs paging, string city = null)
        {
            Paging = paging;
            City = city;
        }
        public QueryArgs Paging { get; set; }
        public string City { get; set; }
    }
}
