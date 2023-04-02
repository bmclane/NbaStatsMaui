using Sharpnado.TaskLoaderView;

namespace NbaStatsMaui.ViewModels;

public partial class TeamsViewModel : BaseViewModel
{
    public TaskLoaderNotifier<List<Team>> Loader { get; }

    public TeamsViewModel(INbaApiService nbaApiService) : base(nbaApiService)
    {
        Loader = new TaskLoaderNotifier<List<Team>>(LoadData);
    }

    public override Task InitializeAsync()
    {
        Loader.Load();

        return base.InitializeAsync();

    }

    public async Task<List<Team>> LoadData(bool isRefresh)
    {
        var response = await NbaApiService.GetTeams();

        return response.Data;
    }

}
