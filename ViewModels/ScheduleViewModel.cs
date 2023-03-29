using Sharpnado.TaskLoaderView;

namespace NbaStatsMaui.ViewModels;

public partial class ScheduleViewModel : BaseViewModel
{

    [ObservableProperty]
    public List<ModelDate> dates = GetDateRange(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(7)).ToList();

    [ObservableProperty]
    public ModelDate selectedDate;

    public TaskLoaderNotifier<List<Game>> Loader { get; }

    public ScheduleViewModel(INbaApiService apiService) : base(apiService)
    {
        Loader = new TaskLoaderNotifier<List<Game>>(LoadData);
    }

    public override async Task InitializeAsync()
    {
        await Task.Delay(200);

        SelectedDate = Dates[7];
        
        Loader.Load();
        await base.InitializeAsync();
    }

    public async Task<List<Game>> LoadData(bool isRefresh)
    {
        var response = await NbaApiService.GetGames(SelectedDate.Date);

        List<Game> ordered = response.Data.OrderByDescending(g => g.Active).ThenBy(g => g.Period).ThenByDescending(g => g.Pregame).ThenByDescending(g => g.Completed).ThenBy(g => g.GameStart).ToList();
        
        return ordered;
    }

    public int GetSelectedIndex()
    {
        return Dates.IndexOf(SelectedDate);
    }

    private static IEnumerable<ModelDate> GetDateRange(DateTime startDate, DateTime endDate)
    {
        //set dates to date
        startDate = startDate.Date;
        endDate = endDate.Date;

        if (endDate < startDate)
            throw new ArgumentException("endDate must be greater than or equal to startDate");

        while (startDate <= endDate)
        {
            yield return new ModelDate(startDate);

            startDate = startDate.AddDays(1);
        }

    }
}
