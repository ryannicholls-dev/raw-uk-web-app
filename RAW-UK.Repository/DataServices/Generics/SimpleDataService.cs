using System.Linq.Expressions;

namespace RAW_UK.Repository;

public class SimpleDataService<TEntity> where TEntity : class
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGenericRepository<TEntity> repository;

    public SimpleDataService(UnitOfWork _unitOfWork, GenericRepository<TEntity> _repository)
    {
        unitOfWork = _unitOfWork;
        repository = _repository;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, params string[] includeProperties)
    {
        return await repository.GetAllAsync(filter, includeProperties);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await repository.InsertAsync(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await repository.UpdateAsync(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await repository.RemoveAsync(id);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task Upsert(TEntity entity)
    {
        await repository.Upsert(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task ArchiveAsync(TEntity entity)
    {
        await repository.ArchiveAsync(entity);
        await unitOfWork.SaveChangesAsync();
    }
    public async Task UnArchiveAsync(TEntity entity)
    {
        await repository.UnArchiveAsync(entity);
        await unitOfWork.SaveChangesAsync();
    }
}
