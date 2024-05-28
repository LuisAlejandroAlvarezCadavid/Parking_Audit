namespace ParkingAudit.Infrastructure.Ports
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
