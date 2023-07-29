using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Data;

public class WebApiDbContext: IdentityDbContext<UserEntity>
{
    private readonly string _connectionString;
    
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options): base(options){}
    
    public WebApiDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<GoalEntity> Goals { get; set; }
    public DbSet<PlayerEntity> Players  { get; set; }
    public DbSet<PlayerBankEntity> PlayerBank  { get; set; }
    public DbSet<PlayerBillEntity> PlayerBills  { get; set; }
    
    public DbSet<PlayerGameEntity> PlayersGames  { get; set; }
    
    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));
        
        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
        
            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
            }
        }
        return base.SaveChanges();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(WebApiDbContext).Assembly);

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }
}