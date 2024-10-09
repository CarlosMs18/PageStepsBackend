using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(PagePasosDbContext context) : base(context)
        {         
        }
    }
}
