using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Offers.Queries;
using RealEstateScrapper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Offers.Handlers
{
    public class GetOfferHandler : IRequestHandler<GetOfferQuery, Result<OfferDto>>
    {
        public async Task<Result<OfferDto>> Handle(GetOfferQuery request, CancellationToken cancellationToken)
        {
        }
    }
}
