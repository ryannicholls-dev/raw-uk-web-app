using System.Linq.Expressions;

namespace RAW_UK.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync (int Id);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, params string[] includeProperties);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(int id);
    Task ArchiveAsync(TEntity entity);
    Task UnArchiveAsync(TEntity entity);
    Task Upsert(TEntity entity);
}
