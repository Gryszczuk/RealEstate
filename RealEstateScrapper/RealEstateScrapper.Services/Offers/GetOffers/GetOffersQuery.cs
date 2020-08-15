using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersQuery : IRequest<Result<OfferDto>>
    {
        public GetOffersQuery(Guid id)
        {
            Id = id;
        }
        public GetOffersQuery(QueryArgsDto paging, string city = null)
        {
            Paging = paging;
            City = city;
        }
        public Guid Id { get; set; }
        public QueryArgsDto Paging { get; set; }
        public string City { get; set; }

    }
}
