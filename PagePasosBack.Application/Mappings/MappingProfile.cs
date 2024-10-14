using AutoMapper;
using PagePasosBack.Application.Features.Companies.Queries;
using PagePasosBack.Application.Features.Departments.Queries;
using PagePasosBack.Application.Features.Districts.Queries;
using PagePasosBack.Application.Features.Provinces.Queries;

namespace PagePasosBack.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Ubigeo
            this.AddMapGetAllDepartmentListQuery();
            this.AddMapGetAllDistrictListQuery();
            this.AddMapGetAllProvinceListQuery();
            #endregion

            #region Company
            this.AddMapGetCompanyByIdQuery();
            #endregion
        }
    }
}
