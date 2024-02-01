
namespace RAW_UK.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RawUKDbContext dbContext;
    public UnitOfWork(RawUKDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
