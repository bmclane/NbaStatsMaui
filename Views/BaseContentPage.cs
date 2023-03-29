using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace NbaStatsMaui.Views;

public abstract class BaseContentPage : ContentPage
{
    public BaseContentPage()
    {
        On<iOS>().SetUseSafeArea(false);
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
