using GameList.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameList.DataAccess.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasMany(t => t.Games)
            .WithMany(t => t.Tags);

        builder
            .Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired();
    }

    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagEntity>()
            .HasIndex(t=> t.Name)
            .IsUnique();
    }
}

