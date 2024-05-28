using Microsoft.EntityFrameworkCore;
using ParkingAudit.Infrastructure.DataContext;
using ParkingAudit.Infrastructure.Ports;

namespace ParkingAudit.Infrastructure.Adapters
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IntegracionDbContext _integracionDbContext;

        public GenericRepository(IntegracionDbContext integracionDbContext)
        {
            _integracionDbContext = integracionDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _integracionDbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _integracionDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _integracionDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken)
        {
            return await _integracionDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _integracionDbContext.Set<TEntity>().Update(entity));
            await _integracionDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _integracionDbContext.Set<TEntity>().ExecuteDeleteAsync(cancellationToken);
            await _integracionDbContext.SaveChangesAsync();
            return true;
        }
    }
}
