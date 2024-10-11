using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PagePasosBack.Application.Contracts.Persistence;
using PagePasosBack.Infrastructure.Persistence;
using PagePasosBack.Infrastructure.Repositories;

namespace PagePasosBack.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PagePasosDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
           );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}