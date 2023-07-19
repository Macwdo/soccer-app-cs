namespace WebApiDotnet.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDotnet.Entities;


public class GoalConfiguration : IEntityTypeConfiguration<GoalEntity>
{
    void IEntityTypeConfiguration<GoalEntity>.Configure(EntityTypeBuilder<GoalEntity> builder)
    {
        builder.ToTable("Goal");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.CreatedAt);
        builder.Property(g => g.UpdatedAt);

        builder.HasOne(g => g.PlayerGame)
            .WithMany(pg => pg.Goals);
    }
}
