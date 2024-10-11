using AutoMapper;
using MediatR;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Application.Mappings;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Application.Features.Departments.Queries
{
    public class GetAllDepartmentListQuery : IRequest<IEnumerable<GetAllDepartmentListQueryResponse>>
    {
    }

    public class GetAllDepartmentListQueryResponse 
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public static  class GetAllDepartmentListQueryMapper
    {
        public static void AddMapGetAllDepartmentListQuery(this MappingProfile mappingProfile)
        {
            mappingProfile.CreateMap<Department, GetAllDepartmentListQueryResponse>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Code, opt => opt.MapFrom(o => o.Code));
        }
    }
    public class GetAllDepartmentListQueryHandler : IRequestHandler<GetAllDepartmentListQuery, IEnumerable<GetAllDepartmentListQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDepartmentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllDepartmentListQueryResponse>> Handle(GetAllDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentsList = await _unitOfWork.DepartmentRepository.GetAsync();
            return  _mapper.Map<IEnumerable<GetAllDepartmentListQueryResponse>>(departmentsList);
         
        }
    }

}
