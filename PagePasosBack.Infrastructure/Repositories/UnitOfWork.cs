using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Domain;
using PagePasosBack.Infrastructure.Persistence;
using System.Collections;

namespace PagePasosBack.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly PagePasosDbContext _context;
        private IDbContextTransaction transaction;
        public ICompanyRepository companyRepository;
        public IDistrictRepository districtRepository;
        public IProvinceRepository provinceRepository;


        public UnitOfWork(PagePasosDbContext context)
        {
            _context = context;
        }

        public PagePasosDbContext ExamPrepDbContext => _context;

        public ICompanyRepository CompanyRepository => companyRepository ??= new CompanyRepository(_context);
        public IProvinceRepository ProvinceRepository => provinceRepository ??=new ProvinceRepository(_context);
        public IDistrictRepository DistrictRepository => districtRepository ??= new DistrictRepository(_context);

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public Task BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public async Task<int> ExecStoreProcedure(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
        public async Task Rollback()
        {
            await transaction.RollbackAsync();
        }
        public async Task Commit()
        {
            await transaction.CommitAsync();
        }
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

    }
}
