using GameList.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GameList.DataAccess.Repositories;

public class GamesRepository
{
    private readonly GameListDbContext _dbContext;

    public GamesRepository(GameListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GameEntity>> Get()
    {
        return await _dbContext.Games
            .AsNoTracking()
            .Include(g => g.Tags)
            .ToListAsync();
    }
}
