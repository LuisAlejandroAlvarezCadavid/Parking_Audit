using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingAudit.Infrastructure.Entities;

namespace ParkingAudit.Infrastructure.DataContext
{
    public class IntegracionDbContext : DbContext
    {
        readonly IConfiguration _configuration;
        public IntegracionDbContext(DbContextOptions<IntegracionDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            this.Database.SetCommandTimeout(180);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                return;
            }

            // load all entity config from current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IntegracionDbContext).Assembly);

            var databaseSchemaName = _configuration.GetSection("DatabaseSchemaName").Value;
            modelBuilder.HasDefaultSchema(databaseSchemaName);

            modelBuilder.Entity<Logs>();


            // ghost properties for audit
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(DomainEntity).IsAssignableFrom(t))
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("FechaCreacion");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("FechaModificacion");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
