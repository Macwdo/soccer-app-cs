namespace WebApiDotnet.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Entities;

public class PlayerGameConfiguration : IEntityTypeConfiguration<PlayerGameEntity>
{
    void IEntityTypeConfiguration<PlayerGameEntity>.Configure(EntityTypeBuilder<PlayerGameEntity> builder)
    {
        builder.ToTable("PlayerGame");
        builder.HasIndex(pg => pg.Id);

        builder.Property(pg => pg.CreatedAt);
        builder.Property(pg => pg.UpdatedAt);

        builder.HasMany(g => g.Goals)
            .WithOne(g => g.PlayerGame)
            .HasForeignKey(g => g.PlayerGameId)
            .IsRequired();

        builder.HasOne(pg => pg.Player)
            .WithMany(p => p.PlayerGames)
            .HasForeignKey(pg => pg.PlayerId)
            .IsRequired();
        
        builder.HasOne(pg => pg.Game)
            .WithMany(p => p.PlayerGames)
            .HasForeignKey(pg => pg.GameId)
            .IsRequired();
    }
}
