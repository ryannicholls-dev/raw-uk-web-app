namespace RAW_UK.Repository;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
