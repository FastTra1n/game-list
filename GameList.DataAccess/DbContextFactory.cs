using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GameList.DataAccess;

public class DbContextFactory : IDesignTimeDbContextFactory<GameListDbContext>
{
    public GameListDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GameListDbContext>();
        optionsBuilder.UseSqlite("Data Source=gamelist.db");

        return new GameListDbContext(optionsBuilder.Options);
    }
}
