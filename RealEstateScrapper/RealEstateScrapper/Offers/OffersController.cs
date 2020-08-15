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

        [HttpGet("/offers/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetOfferQuery(id));
            return Ok(result);
        }
    }
}
