using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.EnviromentImpacts.Queries;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentImpactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnvironmentImpactController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> ListEnvironmentImpactByDistrict([FromQuery] int districtId)
        {
            return Ok(await _mediator.Send(new GetEnvironmentImpactByDistrict {districtId = districtId}));      
        }
    }
}
