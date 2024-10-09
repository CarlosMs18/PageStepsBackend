using PagePasosBack.Domain;

namespace PagePasosBack.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IProvinceRepository ProvinceRepository { get; } 
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        Task<int> ExecStoreProcedure(string sql, params object[] parameters);
        Task Rollback();
        Task Commit();
        Task BeginTransaction();
    }
}
