using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateScrapper.Services.Helpers;
using RealEstateScrapper.Services.Offers.GetOffers;
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

        [HttpGet("/offers")]
        public async Task<IActionResult> Get([FromQuery] QueryArgsDto query)
        {
            var result = await _mediator.Send(new GetOffersQuery(query));
            return Ok(result);
        }

        [HttpGet("/offers/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetOffersQuery(id));
            return Ok(result);
        }


        [HttpGet("offers/{city}")]
        public async Task<IActionResult> GetOffersForCity(string city,[FromQuery] QueryArgsDto query)
        {
            var result = await _mediator.Send(new GetOffersQuery(query, city));
            return Ok(result);
        }
    }
}
