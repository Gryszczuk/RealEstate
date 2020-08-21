using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateScrapper.Models;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Models.Helpers;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace RealEstateScrapper.Services.Mappers
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ReverseMap();
            //todo make generic
            CreateMap<PagedList<Offer>, PagedList<OfferDto>>()
                .ConvertUsing<PagedListConverter<Offer, OfferDto>>();
        }
    }
    public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>> where TSource : class where TDestination : class
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
        {
            var collection = context.Mapper.Map<List<TSource>, List<TDestination>>(source);
            return PagedList<TDestination>.Create(collection, source.CurrentPage, source.PageSize, source.TotalPages);
        }
    }
}
