using AutoMapper;
using MediatR;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Application.Mappings;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Application.Features.Districts.Queries
{
    public class GetAllDistrictListQuery : IRequest<IEnumerable<GetAllDistrictListQueryResponse>>
    {
    }


    public class GetAllDistrictListQueryResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }        
        public int ProvinceId { get; set; }
    }

    public static class GetAllDistrictListQueryMapper
    {
        public static void AddMapGetAllDistrictListQuery(this MappingProfile mappingProfile)
        {
            mappingProfile.CreateMap<District, GetAllDistrictListQueryResponse>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Code, opt => opt.MapFrom(o => o.Code))
                .ForMember(d => d.ProvinceId, opt => opt.MapFrom(o => o.ProvinceId));     
        }
    }

    public class GetAllDistrictListQueryHandler : IRequestHandler<GetAllDistrictListQuery, IEnumerable<GetAllDistrictListQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDistrictListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllDistrictListQueryResponse>> Handle(GetAllDistrictListQuery request, CancellationToken cancellationToken)
        {
            var districtList = await _unitOfWork.DistrictRepository.GetAsync();
            return _mapper.Map<IEnumerable<GetAllDistrictListQueryResponse>>(districtList);        
        }
    }



}
