using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System;

namespace RealEstateScrapper.Services.Offers.GetOfferDetails
{
    public class GetOfferDetailsQuery : IRequest<Result<OfferDto>>
    {
        public GetOfferDetailsQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
