using GameList.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameList.DataAccess.Configurations;

public class CollectionConfiguration : IEntityTypeConfiguration<CollectionEntity>
{
    public void Configure(EntityTypeBuilder<CollectionEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(c => c.Games)
            .WithMany(g => g.Collections);

        builder
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();
    }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionEntity>()
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}
