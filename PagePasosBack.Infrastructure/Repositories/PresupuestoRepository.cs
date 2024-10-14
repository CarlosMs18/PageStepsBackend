using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class PresupuestoRepository : RepositoryBase<Presupuesto>, IPresupuestoRepository
    {
        public PresupuestoRepository(PagePasosDbContext context) : base(context)
        {
        }
    }
}
