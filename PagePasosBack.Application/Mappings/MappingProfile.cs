using AutoMapper;
using PagePasosBack.Application.Features.Departments.Queries;

namespace PagePasosBack.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.AddMapGetAllDepartmentListQuery();
        }
    }
}
