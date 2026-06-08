using GameList.Core.Models;
using GameList.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GameList.DataAccess;

public class GameListDbContext(DbContextOptions<GameListDbContext> options)
    : DbContext(options)
{
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<CollectionEntity> Collections { get; set; }
    public DbSet<TagEntity> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new CollectionConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}
