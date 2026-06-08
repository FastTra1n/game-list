namespace GameList.Core.Models;

public class GameEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Progress { get; set; } = 0;
    public int Rating { get; set; } = 0;
    public string CoverURL { get; set; } = string.Empty;
    public List<TagEntity> Tags { get; set; } = [];
    public List<CollectionEntity> Collections { get; set; } = [];   
}
