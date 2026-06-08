using GameList.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameList.DataAccess.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.HasKey(g => g.Id);

        builder
            .HasMany(g => g.Tags)
            .WithMany(t => t.Games);
        builder
            .HasMany(g => g.Collections)
            .WithMany(c => c.Games);

        builder
            .Property(g => g.Title)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(g => g.Progress)
            .HasDefaultValue(0);
        builder
            .Property(g => g.Rating)
            .HasDefaultValue(0);
    }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameEntity>()
            .ToTable(t => t.HasCheckConstraint("Progress", "Progress >= 0 AND Progress <= 100"));
        modelBuilder.Entity<GameEntity>()
            .ToTable(t => t.HasCheckConstraint("Rating", "Rating >= 1 AND Rating <= 10"));
    }
}
