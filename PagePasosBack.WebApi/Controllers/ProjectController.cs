using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.Projects.Commands;

namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            return Ok(await _mediator.Send(command));  
        }
    }
}
