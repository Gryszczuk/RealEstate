using MediatR;
using RealEstateScrapper.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateScrapper.Offers.Queries
{
    public class GetOfferQuery : IRequest<OfferDto>
    {
        public Guid Id { get; set; }
    }
}
