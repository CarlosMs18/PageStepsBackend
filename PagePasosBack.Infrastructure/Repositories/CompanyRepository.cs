using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain.Licitacion;
using PagePasosBack.Infrastructure.Persistence;

namespace PagePasosBack.Infrastructure.Repositories
{
    public  class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(PagePasosDbContext context) : base(context)
        {
            
        }
    }
}
