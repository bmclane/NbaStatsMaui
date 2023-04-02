using CommunityToolkit.Maui.Core.Extensions;
using NbaStatsMaui.Views;
using Sharpnado.TaskLoaderView;
using System.Collections.ObjectModel;

namespace NbaStatsMaui.ViewModels;

public partial class ScheduleViewModel : BaseViewModel
{

    [ObservableProperty]
    public ObservableCollection<ModelDate> dates;

    [ObservableProperty]
    public ModelDate selectedDate;

    [RelayCommand]
    void DateChanged()
    {
        foreach (var dateSelected in Dates)
        {
            if (dateSelected.Equals(SelectedDate))
            {
                dateSelected.IsSelected = true;
            }
            else
            {
                dateSelected.IsSelected = false;
            }
        }
    }

    [RelayCommand]
    private async void GoToGameDetails(Game item)
    {
        await Shell.Current.GoToAsync(nameof(GameDetailPage), true, new Dictionary<string, object>
        {
            { "Game", item }
        });
    }

    public TaskLoaderNotifier<List<Game>> Loader { get; }

    public ScheduleViewModel(INbaApiService apiService) : base(apiService)
    {
        Dates = GetDateRange(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(7)).ToObservableCollection();
        
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
