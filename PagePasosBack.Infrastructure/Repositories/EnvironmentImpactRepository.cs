using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class EnvironmentImpactRepository : RepositoryBase<EnvironmentImpact>, IEnvironmentImpactRepository
    {
        public EnvironmentImpactRepository(PagePasosDbContext context) : base(context)
        {
        }
    }
}
