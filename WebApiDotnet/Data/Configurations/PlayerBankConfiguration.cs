namespace WebApiDotnet.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Entities;

public class PlayerBankConfiguration : IEntityTypeConfiguration<PlayerBankEntity>
{
    public void Configure(EntityTypeBuilder<PlayerBankEntity> builder)
    {
        builder.ToTable("PlayerBank");
        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.PixKey);

        builder.Property(pb => pb.CreatedAt);
        builder.Property(pb => pb.UpdatedAt);

        builder.HasOne(pb => pb.Player)
            .WithOne(p => p.PlayerBank)
            .HasForeignKey<PlayerEntity>(p => p.PlayerBankId)
            .IsRequired();
    }
}
