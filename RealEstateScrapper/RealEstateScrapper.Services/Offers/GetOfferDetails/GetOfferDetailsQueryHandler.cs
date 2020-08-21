using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Offers.GetOfferDetails
{
    public class GetOfferDetailsQueryHandler : IRequestHandler<GetOfferDetailsQuery, Result<OfferDto>>
    {
        public Task<Result<OfferDto>> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
