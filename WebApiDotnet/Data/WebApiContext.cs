using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Models;

namespace WebApiDotnet.Data;

public class WebApiContext: DbContext
{
    private readonly string _connectionString;
    
    public WebApiContext(DbContextOptions<WebApiContext> options): base(options){}
    
    public WebApiContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
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
    
    public DbSet<User?> User { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(WebApiContext).Assembly);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }
}