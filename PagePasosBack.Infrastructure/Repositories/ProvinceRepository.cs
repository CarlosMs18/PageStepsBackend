using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(PagePasosDbContext context) : base(context)
        {
            
        }
    }
}
