using AutoMapper;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Dto;

namespace RealEstateScrapper.Services.Mappers
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ReverseMap();
        }
    }
}
