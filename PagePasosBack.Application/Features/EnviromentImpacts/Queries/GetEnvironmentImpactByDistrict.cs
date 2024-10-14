using MediatR;
using PagePasosBack.Application.Contracts.Persistence;

namespace PagePasosBack.Application.Features.EnviromentImpacts.Queries
{
    public class GetEnvironmentImpactByDistrict : IRequest<IEnumerable<GetEnvironmentImpactByDistrictResponse>>
    {
        public int districtId { get; set; }
    }

    public class GetEnvironmentImpactByDistrictResponse
    {
        public int environmentImpactTypeId { get; set; }
        public string environmentImpactType { get; set; }

        public int districtId { get; set; }
    }

    public class GetEnvironmentImpactByDistrictHandler : IRequestHandler<GetEnvironmentImpactByDistrict, IEnumerable<GetEnvironmentImpactByDistrictResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEnvironmentImpactByDistrictHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetEnvironmentImpactByDistrictResponse>> Handle(GetEnvironmentImpactByDistrict request, CancellationToken cancellationToken)
        {
            var enviromentImpactList =  await _unitOfWork.EnvironmentImpactRepository.GetAsync(
                c => c.DistrictId == request.districtId,
                null,
                true,
                c => c.District
                );

            return enviromentImpactList
                    .Select(x => new GetEnvironmentImpactByDistrictResponse
                    {
                        environmentImpactTypeId = x.Id,
                        environmentImpactType = x.EnvironmentImpactType,
                        districtId = x.DistrictId,
                    }).ToList();
        }
    }
}
