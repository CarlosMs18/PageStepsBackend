using AutoMapper;
using PagePasosBack.Application.Features.Departments.Queries;
using PagePasosBack.Application.Features.Districts.Queries;

namespace PagePasosBack.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.AddMapGetAllDepartmentListQuery();
            this.AddMapGetAllDistrictListQuery();
        }
    }
}
