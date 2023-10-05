using Application.Features.RealtyFeatures.CreateRealty;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class RealtyController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RealtyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Realty")]
        public async Task<ActionResult<CreateRealtyResponse>> Create([FromQuery] CreateRealtyRequest request, CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
