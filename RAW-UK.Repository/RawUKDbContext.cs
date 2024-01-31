using Microsoft.EntityFrameworkCore;
using RAW_UK.Model;


namespace RAW_UK.Repository;

public class RawUKDbContext : DbContext
{
    public RawUKDbContext(DbContextOptions<RawUKDbContext> options) : base (options) { } 
    public DbSet<SignUp> SignUp { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SignUp>(entity => {
            
            entity.ToTable($"{nameof(SignUp)}s");

            entity.HasKey(e => e.Id);

            entity.Property(x => x.FirstName)
                  .HasMaxLength(100);

            entity.Property(x => x.LastName)
                  .HasMaxLength(100);

            entity.Property(x => x.Email)
                  .HasMaxLength(100);

            entity.Property(x => x.Mobile)
                  .HasMaxLength(100);

        });

        base.OnModelCreating(modelBuilder);
    }
}
