using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.Departments.Queries;
using PagePasosBack.Application.Features.Provinces.Queries;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ListProvince()
        {
            return Ok(await _mediator.Send(new GetAllProvinceListQuery()));       
        }
    }
}
