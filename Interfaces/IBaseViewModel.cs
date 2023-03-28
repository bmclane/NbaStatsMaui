namespace NbaStatsMaui.Interfaces;

public interface IBaseViewModel
{
    public bool IsBusy { get; }

    public bool IsInitialized { get; set; }

    Task InitializeAsync();
}
