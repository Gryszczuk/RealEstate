using AutoMapper;
using MediatR;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Services.Helpers;
using RealEstateScrapper.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOfferDetailsHandler : IRequestHandler<GetOfferDetailsQuery, Result<OfferDto>>
    {
        protected IMapper _mapper;
        protected IOfferRepository _repository;
        public GetOfferDetailsHandler(IMapper mapper, 
            IOfferRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Result<OfferDto>> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        {
            var offer = _repository.GetById(request.Id);
            var offerDto = _mapper.Map<OfferDto>(offer);
            return Result.Ok(offerDto);
        }
    }
}
