using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateScrapper.Models.Dto;
using RealEstateScrapper.Offers.Queries;
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

        [HttpPost("/offers/{id}")]
        public async Task<IActionResult> Get([FromBody] GetOfferQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
