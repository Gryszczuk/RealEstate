using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services;
using System;

namespace RealEstateScrapper.Offers.Queries
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
