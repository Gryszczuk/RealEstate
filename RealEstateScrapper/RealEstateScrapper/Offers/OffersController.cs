using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateScrapper.Services.Offers.GetOffers;
using RealEstateScrapper.Services.Offers.GetOffersInCity;
using System;
using System.Threading.Tasks;

namespace RealEstateScrapper.Offers
{
    [Controller]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/offers/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetOfferQuery(id));
            return Ok(result);
        }
        [HttpGet("offers/{city}")]
        public async Task<IActionResult> GetOffersForCity(string city)
        {
            var result = await _mediator.Send(new GetOffersInCityQuery(city));
            return Ok(result);
        }
    }
}
