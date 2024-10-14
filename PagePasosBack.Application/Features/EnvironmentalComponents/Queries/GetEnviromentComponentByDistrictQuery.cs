using MediatR;
using PagePasosBack.Application.Contracts.Persistence;

namespace PagePasosBack.Application.Features.EnvironmentalComponents.Queries
{
    public class GetEnviromentComponentByDistrictQuery : IRequest<IEnumerable<GetEnviromentComponentByDistrictQueryResponse>>
    {
        public int districtId { get; set; } 
    }

    public class GetEnviromentComponentByDistrictQueryResponse
    {
        public int id { get; set; }
        public string enviromentComponentType { get; set; } 
        public int districtId { get; set;}
    }


    public class GetEnviromentComponentByDistrictQueryHandler : IRequestHandler<GetEnviromentComponentByDistrictQuery, IEnumerable<GetEnviromentComponentByDistrictQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEnviromentComponentByDistrictQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetEnviromentComponentByDistrictQueryResponse>> Handle(GetEnviromentComponentByDistrictQuery request, CancellationToken cancellationToken)
        {
            var enviromentComponentList =  await _unitOfWork.EnvironmentComponentRepository.GetAsync(
                c => c.DistrictId == request.districtId,
                null,
                true,
                c => c.District
                );

            return enviromentComponentList
                    .Select(x => new GetEnviromentComponentByDistrictQueryResponse
                    {
                        id = x.Id,
                        enviromentComponentType = x.EnviromentComponentType,
                        districtId = x.DistrictId
                    }).ToList();                     
        }
    }



}
