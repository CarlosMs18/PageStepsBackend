using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class EnvironmentComponentRepository : RepositoryBase<EnvironmentalComponent>, IEnvironmentComponentRepository
    {
        public EnvironmentComponentRepository(PagePasosDbContext context) : base(context)
        {
        }
    }
}
