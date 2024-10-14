using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.EnvironmentalComponents.Queries;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviromentComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnviromentComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ListCompanyByDistrict([FromQuery] int districtId)
        {
            return Ok(await _mediator.Send(new GetEnviromentComponentByDistrictQuery { districtId = districtId}));
        }
    }
}
