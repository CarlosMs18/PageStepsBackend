using PagePasosBack.Domain;

namespace PagePasosBack.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IDepartmentRepository  DepartmentRepository { get; }    
        IDistrictRepository DistrictRepository { get; }
        IProvinceRepository ProvinceRepository { get; } 
        IEnvironmentComponentRepository EnvironmentComponentRepository { get; }
        IEnvironmentImpactRepository EnvironmentImpactRepository { get; }   
        IProjectRepository ProjectRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        Task<int> ExecStoreProcedure(string sql, params object[] parameters);
        Task Rollback();
        Task Commit();
        Task BeginTransaction();
    }
}
