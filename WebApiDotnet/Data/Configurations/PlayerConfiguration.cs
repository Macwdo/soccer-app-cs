using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Entities;

namespace WebApiDotnet.Data;

public class PlayerConfiguration : IEntityTypeConfiguration<PlayerEntity>
{
    void IEntityTypeConfiguration<PlayerEntity>.Configure(EntityTypeBuilder<PlayerEntity> builder)
    {
        builder.ToTable("Player");
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(20);

        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.UpdatedAt);

        // Relação One-to-One com a entidade UserEntity
        builder.HasOne(p => p.User)
            .WithOne(u => u.Player)
            .HasForeignKey<PlayerEntity>(p => p.UserId)
            .IsRequired(false);

        // Relação One-to-Many com a entidade PlayerBillEntity
        builder.HasMany(p => p.PlayerBills)
            .WithOne(pb => pb.Player)
            .HasForeignKey(pb => pb.PlayerId)
            .IsRequired();

        // Relação One-to-One com a entidade PlayerBankEntity
        builder.HasOne(p => p.PlayerBank)
            .WithOne(pb => pb.Player)
            .HasForeignKey<PlayerEntity>(p => p.PlayerBankId)
            .IsRequired(false);
        

    }
}
