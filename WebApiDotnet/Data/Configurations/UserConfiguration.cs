using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Models;

namespace WebApiDotnet.Data;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(t => t.Id);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Password).IsRequired();

        builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

        builder.HasIndex(p => p.Email).IsUnique();
    }
}