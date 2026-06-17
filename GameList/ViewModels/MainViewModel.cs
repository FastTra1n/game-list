using GameList.Core.Models;
using GameList.DataAccess.Repositories;
using System.Collections.ObjectModel;

namespace GameList.ViewModels;

public class MainViewModel
{
    public readonly GamesRepository _repository;
    public ObservableCollection<GameEntity> Games { get; set; } = [];

    public MainViewModel(GamesRepository repository)
    {
        _repository = repository;
        _ = LoadAsync();
    }

    public async Task LoadAsync()
    {
        List<GameEntity> gamesList = await _repository.Get();
        Games.Clear();
        foreach (var game in gamesList)
        {
            Games.Add(game);
        }
    }
}
