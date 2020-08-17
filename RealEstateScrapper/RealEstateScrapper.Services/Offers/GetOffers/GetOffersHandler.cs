using AutoMapper;
using MediatR;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersHandler : IRequestHandler<GetOffersQuery, Result<List<OfferDto>>>
    {
        protected IMapper _mapper;
        public GetOffersHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Result<List<OfferDto>>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            
            var offer = new Offer
            {
                Id = new Guid(),
                Name = "testing name"
            };
            var offerDto = _mapper.Map<OfferDto>(offer);
            List <OfferDto> list = new List<OfferDto>();
            list.Add(offerDto);
            return Result.Ok(list);
        }
    }
}
