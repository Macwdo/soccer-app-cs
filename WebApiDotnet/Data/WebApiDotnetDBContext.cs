using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Models;

namespace WebApiDotnet.Data;

public class WebApiDotnetDBContext: DbContext
{
    public WebApiDotnetDBContext(DbContextOptions<WebApiDotnetDBContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<UserModel> User { get; set; }
    public DbSet<TasksModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}