using AutoMapper;
using PagePasosBack.Application.Features.Departments.Queries;
using PagePasosBack.Application.Features.Districts.Queries;
using PagePasosBack.Application.Features.Provinces.Queries;

namespace PagePasosBack.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.AddMapGetAllDepartmentListQuery();
            this.AddMapGetAllDistrictListQuery();
            this.AddMapGetAllProvinceListQuery();

        }
    }
}
