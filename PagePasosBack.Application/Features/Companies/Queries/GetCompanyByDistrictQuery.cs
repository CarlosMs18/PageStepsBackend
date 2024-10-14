using AutoMapper;
using MediatR;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Application.Mappings;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Application.Features.Companies.Queries
{
    public class GetCompanyByDistrictQuery : IRequest<IEnumerable<GetCompanyByDistrictQueryResponse>>
    {
        public int DistrictId { get; set; }
    }

    public class GetCompanyByDistrictQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName  { get; set; }
    }

    public static class GetCompanyByDistrictQueryMapper
    {
        public static void AddMapGetCompanyByIdQuery(this MappingProfile mappingProfile)
        {
            mappingProfile.CreateMap<Company, GetCompanyByDistrictQueryResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom( o => o.Name))
                .ForMember(d => d.DistrictId, opt => opt.MapFrom( o => o.DistrictId))
                .ForMember(d => d.DistrictName, opt => opt.MapFrom(o => o.District.Name));
        }
    }

    public class GetCompanyByDistrictQueryHandler : IRequestHandler<GetCompanyByDistrictQuery, IEnumerable<GetCompanyByDistrictQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCompanyByDistrictQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCompanyByDistrictQueryResponse>> Handle(GetCompanyByDistrictQuery request, CancellationToken cancellationToken)
        {
            var companies = await _unitOfWork.CompanyRepository.GetAsync(
                    c => c.DistrictId == request.DistrictId,
                    null,
                    true,
                    c => c.District
                );
            return _mapper.Map<IEnumerable<GetCompanyByDistrictQueryResponse>>(companies); ;
        }
    }
}
