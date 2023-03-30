using Sharpnado.TaskLoaderView;

namespace NbaStatsMaui.ViewModels;

public partial class PlayersViewModel : BaseViewModel
{
    [ObservableProperty]
    string searchText;

    public TaskLoaderNotifier<List<Player>> Loader { get; }

    public PlayersViewModel(INbaApiService apiService) : base(apiService)
    {
        Loader = new TaskLoaderNotifier<List<Player>>(LoadData);
    }
    public async Task<List<Player>> LoadData(bool isRefresh)
    {
        if (string.IsNullOrEmpty(SearchText))
            return new ();

        var response = await NbaApiService.SearchPlayers(SearchText);

        return response.Data.OrderBy(p => p.FullName).ToList();
    }
}
