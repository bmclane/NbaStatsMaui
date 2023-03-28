namespace NbaStatsMaui.Views;

public abstract class BaseContentPage : ContentPage
{
    public BaseContentPage()
    {

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is IBaseViewModel ibvm && !ibvm.IsInitialized)
        {
            ibvm.IsInitialized = true;
            await ibvm.InitializeAsync();
        }
    }
}
