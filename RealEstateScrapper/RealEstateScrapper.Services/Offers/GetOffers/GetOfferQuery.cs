using MediatR;
using RealEstateScrapper.Models.Dto;
using System;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOfferQuery : IRequest<Result<OfferDto>>
    {
        public GetOfferQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
