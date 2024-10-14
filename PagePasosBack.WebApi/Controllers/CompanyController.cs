using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.Companies.Queries;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ListCompanyByDistrict([FromQuery] int districtId)
        {
            return Ok(await _mediator.Send(new GetCompanyByDistrictQuery { DistrictId = districtId}));
        }
    }
}
