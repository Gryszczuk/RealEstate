using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System.Collections.Generic;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersQuery : IRequest<Result<List<OfferDto>>>
    {
        public GetOffersQuery(QueryArgsDto paging, string city = null)
        {
            Paging = paging;
            City = city;
        }
        public QueryArgsDto Paging { get; set; }
        public string City { get; set; }
    }
}
