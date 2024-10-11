using Microsoft.EntityFrameworkCore;
using PagePasosBack.Domain;
using PagePasosBack.Domain.Licitacion;

namespace PagePasosBack.Infrastructure.Persistence
{
    public class PagePasosDbContext :DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Company> Companies { get; set; }
        public PagePasosDbContext(DbContextOptions<PagePasosDbContext> options) : base(options)
        {         
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<District>().Property(x => x.Code).IsRequired(false);

            builder.Entity<Province>().Property(x => x.Code).IsRequired(false);

            builder.Entity<Department>().Property(x => x.Code).IsRequired(false);

            builder.Entity<Company>().Property(x => x.Name).IsRequired(false);

            #region Province    
            builder.Entity<Province>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Provinces)
                .OnDelete(DeleteBehavior.Cascade);  


            #endregion

            #region District
            builder.Entity<District>()
                .HasOne(x => x.Province)
                .WithMany(x => x.Districts)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion


            #region Company
            builder.Entity<Company>()
                   .HasOne(x => x.Department)
                   .WithMany(x => x.Companies)
                   .OnDelete(DeleteBehavior.Cascade);   

            #endregion
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();

            return base.SaveChangesAsync(cancellationToken);
        }

        public void Audit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => (x.Entity is BaseDomainModel) &&
                     (x.State == EntityState.Added || x.State == EntityState.Modified));

            //var date = DateTime.Now;
            //var user = userSession.Id;
            //var userName = userSession.UserName;
            //var terminal = userSession.ClientIP;

            foreach (var entry in modifiedEntries)
            {
                var entity = (BaseDomainModel)entry.Entity;
                //if (entry.State == EntityState.Added)
                //{
                //    entity.RegisterStatus = "1";
                //    entity.CreatedDate = date;
                //    entity.CreatedBy = user;
                //    entity.TerminalCreation = terminal;
                //}
                //else
                //{
                //    entity.LastModifiedDate = date;
                //    entity.LastModifiedBy = user;
                //    entity.TerminalLastModification = terminal;
                //    //Entry(entidad).Property(x => x.RegisterStatus).IsModified = false;
                //    Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                //    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                //    Entry(entity).Property(x => x.TerminalCreation).IsModified = false;
                //}
            }
        }
    }
}
