namespace WebApiDotnet.Data.Configurations;
using WebApiDotnet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlayerBillConfiguration : IEntityTypeConfiguration<PlayerBillEntity>
{
    void IEntityTypeConfiguration<PlayerBillEntity>.Configure(EntityTypeBuilder<PlayerBillEntity> builder)
    {
        builder.ToTable("PlayerBill");
        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.BillType);
        builder.Property(pb => pb.Value);
        
        builder.Property(pb => pb.CreatedAt);
        builder.Property(pb => pb.UpdatedAt);
        
        builder.HasOne(pb => pb.Player)
            .WithMany(p => p.PlayerBills);
    }
}
