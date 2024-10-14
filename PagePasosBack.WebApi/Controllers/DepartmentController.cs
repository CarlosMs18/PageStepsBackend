using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagePasosBack.Application.Features.Departments.Queries;


namespace PagePasosBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> ListDepartment()
            {
            return Ok(await _mediator.Send(new GetAllDepartmentListQuery()));
        }
      
    }
}
