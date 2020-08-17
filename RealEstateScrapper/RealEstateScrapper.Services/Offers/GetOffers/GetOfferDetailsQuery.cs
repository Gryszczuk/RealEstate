using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Offers.GetOffers
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
