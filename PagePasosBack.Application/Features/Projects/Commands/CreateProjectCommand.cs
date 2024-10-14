using MediatR;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Application.Features.Projects.Commands
{
    public class CreateProjectCommand : IRequest<CreateProjectCommandResponse>
    {
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public double dMinimo { get; set; }
        public double dMaximo { get; set; }
    }

    public class CreateProjectCommandResponse
    {
        public bool Success { get; set; }
        public string? Description { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.GetById(request.CompanyId);
            if (company == null)
            {
                throw new Exception($"Company wasn't no found");
            }

            await _unitOfWork.BeginTransaction();
            try
            {
                var project = new Project { Description = request.Description, CompanyId = company.Id };
                _unitOfWork.ProjectRepository.AddEntity(project);
                await _unitOfWork.Complete();
                var presupuesto = new Presupuesto
                {
                    dMinimo = request.dMinimo,
                    dMaximo = request.dMaximo,
                    ProjectId = project.Id,
                };


                _unitOfWork.PresupuestoRepository.AddEntity(presupuesto);

                await _unitOfWork.Complete();
                await _unitOfWork.Commit();


                return new CreateProjectCommandResponse()
                {
                    Success = true,
                    Description = "The Project was created successfully . "
                };

            }catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }

}
