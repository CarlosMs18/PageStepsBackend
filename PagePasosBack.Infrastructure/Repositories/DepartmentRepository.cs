using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(PagePasosDbContext context) : base(context)
        {
            
        }
    }
}
