using CommunityToolkit.Maui.Core.Extensions;
using Sharpnado.TaskLoaderView;
using System.Collections.ObjectModel;

namespace NbaStatsMaui.ViewModels;

[QueryProperty(nameof(Game), "Game")]
public partial class GameDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    Game game;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedStats))]
    public ObservableCollection<GameStats> homeStats;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedStats))]
    public ObservableCollection<GameStats> visitorStats;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedStats))]
    bool selected = true;

    public ObservableCollection<GameStats> SelectedStats => Selected ? VisitorStats : HomeStats;
    public TaskLoaderNotifier<List<GameStats>> Loader { get; }

    public GameDetailViewModel(INbaApiService nbaApiService) : base(nbaApiService)
    {
        Loader = new TaskLoaderNotifier<List<GameStats>>(LoadData);
    }

    public async Task<List<GameStats>> LoadData(bool isRefresh)
    {
        var response = await NbaApiService.GetGameStats(Game);
        HomeStats = (from player in response.Data where player.Player.TeamId == player.Game.HomeTeamId select player).ToObservableCollection();
        VisitorStats = (from player in response.Data where player.Player.TeamId == player.Game.VisitorTeamId select player).ToObservableCollection();
        return response.Data;
    }

    public override async Task InitializeAsync()
    {
        await Task.Delay(50);
        
        Loader.Load();

        await base.InitializeAsync();
    }
}
