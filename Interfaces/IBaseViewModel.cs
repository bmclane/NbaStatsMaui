namespace NbaStatsMaui.Interfaces;

public interface IBaseViewModel
{
    public bool IsInitialized { get; set; }

    Task InitializeAsync();
}
