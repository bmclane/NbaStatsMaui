using CommunityToolkit.Mvvm.ComponentModel;
using NbaStatsMaui.Interfaces;

namespace NbaStatsMaui.ViewModels;

public partial class BaseViewModel : ObservableObject, IBaseViewModel
{
    [ObservableProperty]
    bool isInitialized;


    public INbaApiService NbaApiService
    {
        get;
        private set;
    }

    public BaseViewModel(INbaApiService nbaApiService)
    {
        NbaApiService = nbaApiService;
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

}
