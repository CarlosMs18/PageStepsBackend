using AutoMapper;
using MediatR;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Application.Mappings;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Application.Features.Provinces.Queries
{
    public class GetAllProvinceListQuery : IRequest<IEnumerable<GetAllProvinceListQueryResponse>>
    {
    }

    public class GetAllProvinceListQueryResponse
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName{ get; set; }
    }

    public static class GetAllProvinceListQueryMapper
    {
        public static void AddMapGetAllProvinceListQuery(this MappingProfile mappingProfile)
        {
            mappingProfile.CreateMap<Province, GetAllProvinceListQueryResponse>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Code, opt => opt.MapFrom(o => o.Code))
                .ForMember(d => d.DepartmentId, opt => opt.MapFrom(o => o.DepartmentId  ))
                .ForMember(d => d.DepartmentName , opt => opt.MapFrom(o => o.Department.Name));
        }
    }

    public class GetAllProvinceListQueryHandler : IRequestHandler<GetAllProvinceListQuery, IEnumerable<GetAllProvinceListQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProvinceListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProvinceListQueryResponse>> Handle(GetAllProvinceListQuery request, CancellationToken cancellationToken)
        {
            var provinceList = await _unitOfWork.ProvinceRepository.GetAsync(
                                                                    null,
                                                                    null,
                                                                    true,
                                                                    d => d.Department);

            return _mapper.Map<IEnumerable<GetAllProvinceListQueryResponse>>(provinceList);
        }
    }
}
