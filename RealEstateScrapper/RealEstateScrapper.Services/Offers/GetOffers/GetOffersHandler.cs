using AutoMapper;
using MediatR;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Models.Helpers;
using RealEstateScrapper.Services.Helpers;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersHandler : IRequestHandler<GetOffersQuery, Result<PagedList<OfferDto>>>
    {
        protected IMapper _mapper;
        protected IOfferRepository _repository;
        public GetOffersHandler(IMapper mapper,
            IOfferRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Result<PagedList<OfferDto>>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetOffers(request.Paging);
            var mappedResult = _mapper.Map<PagedList<OfferDto>>(result);
            return Result.Ok(mappedResult);
        }
    }
}
