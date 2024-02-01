using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RAW_UK.Model;

namespace RAW_UK.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private RawUKDbContext dbContext;

    public GenericRepository(RawUKDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public async Task InsertAsync(TEntity entity)
    {
        await dbContext.Set<TEntity>().AddAsync(entity);
    }
    public async Task UpdateAsync(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
        await dbContext.SaveChangesAsync();
    }
    public async Task ArchiveAsync(TEntity entity)
    {
        var type = entity.GetType();
        var isArchivedProp = type.GetProperty("IsArchived");
        var archiveDateProp = type.GetProperty("ArchivedDate");
        isArchivedProp?.SetValue(entity, true);
        archiveDateProp?.SetValue(entity, DateTime.Now);
        await UpdateAsync(entity);
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, params string[] includeProperties)
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.ToListAsync();
    }
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await dbContext.Set<TEntity>().FindAsync(id);
    }
    public async Task RemoveAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
    public async Task Upsert(TEntity entity)
    {
        var type = entity.GetType();
        var prop = type.GetProperty($"{nameof(BaseEntity.Id)}");
        int id = Convert.ToInt32(prop?.GetValue(entity));
        var record = await GetByIdAsync(id);
        if (record == null)
        {
            await InsertAsync(entity);
        }
        else
        {
            await UpdateAsync(entity);
        }
        await dbContext.SaveChangesAsync();
    }
    public async Task UnArchiveAsync(TEntity entity)
    {
        var type = entity.GetType();
        var isArchivedProp = type.GetProperty("IsArchived");
        var archiveDateProp = type.GetProperty("ArchivedDate");
        isArchivedProp?.SetValue(entity, false);
        archiveDateProp?.SetValue(entity, null);
        await UpdateAsync(entity);
    }
}
