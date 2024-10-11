using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.Districts.Queries;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult> ListDistrict()
        {
            return Ok(await _mediator.Send(new GetAllDistrictListQuery()));
        }
    }
}
