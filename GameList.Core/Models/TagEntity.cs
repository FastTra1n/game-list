namespace GameList.Core.Models;
public class TagEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<GameEntity> Games { get; set; } = [];
}