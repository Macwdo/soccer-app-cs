namespace WebApiDotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Entities;


public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    void IEntityTypeConfiguration<GameEntity>.Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.ToTable("Game");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.GameDate);

        builder.Property(g => g.CreatedAt);
        builder.Property(g => g.UpdatedAt);

    }
}