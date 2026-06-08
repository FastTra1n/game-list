namespace GameList.Core.Models;
public class CollectionEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<GameEntity> Games { get; set; } = [];
}