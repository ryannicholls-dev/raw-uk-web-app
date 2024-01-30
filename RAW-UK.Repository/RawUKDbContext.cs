using Microsoft.EntityFrameworkCore;
using RAW_UK.Model;


namespace RAW_UK.Repository;

public class RawUKDbContext : DbContext
{
    public RawUKDbContext(DbContextOptions<RawUKDbContext> options) : base (options) { } 
    public DbSet<SignUp> SignUp { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SignUp>().ToTable($"{nameof(SignUp)}s");

        base.OnModelCreating(modelBuilder);
    }
}
