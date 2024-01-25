using Application.Common.Models;
using Application.Features.RealtyFeatures.CreateRealty;
using Application.Features.RealtyFeatures.EditRealty;
using Application.Features.RealtyFeatures.GetRealties;
using Application.Features.RealtyHeatingTypeFeatures.CreateRealtyHeatingType;
using Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType;
using Application.Features.RealtyPlanningTypeFeatures.CreateRealtyPlanningType;
using Application.Features.RealtyPlanningTypeFeatures.DeleteRealtyPlanningType;
using Application.Features.RealtyWallTypeFeatures.CreateRealtyWallType;
using Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType;
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

        [HttpPut("Realty")]
        public async Task<ActionResult> Edit([FromQuery] EditRealtyRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("Realties")]
        public async Task<ActionResult<PaginatedList<GetRealtiesResponse>>> GetRealties([FromQuery] GetRealtiesRequest request)
        {
            var response = await _mediator.Send(request);
            var a = User;
            return Ok(response);
        }


        [HttpPost("RealtyPlanningType")]
        public async Task<ActionResult> CreateRealtyPlanningType([FromQuery] CreateRealtyPlanningTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("RealtyPlanningType")]
        public async Task<ActionResult> DeleteRealtyPlanningType([FromQuery] DeleteRealtyPlanningTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("RealtyHeatingType")]
        public async Task<ActionResult> CreateRealtyHeatingType([FromQuery] CreateRealtyHeatingTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("RealtyHeatingType")]
        public async Task<ActionResult> DeleteRealtyHeatingType([FromQuery] DeleteRealtyHeatingTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("RealtyWallType")]
        public async Task<ActionResult> CreateRealtyWallType([FromQuery] CreateRealtyWallTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("RealtyWallType")]
        public async Task<ActionResult> DeleteRealtyWallType([FromQuery] DeleteRealtyWallTypeRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
