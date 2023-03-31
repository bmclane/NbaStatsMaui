using Microsoft.Extensions.Logging;
using NbaStatsMaui.Views;
using SkiaSharp.Views.Maui.Controls.Hosting;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace NbaStatsMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        Sharpnado.TaskLoaderView.Initializer.Initialize(false);

        builder.Services.AddSingleton<INbaApiService, NbaApiService>();
        builder.Services.AddSingleton<ScheduleViewModel>();
        builder.Services.AddSingleton<SchedulePage>();
        builder.Services.AddSingleton<TeamsViewModel>();
        builder.Services.AddSingleton<TeamsPage>();
        builder.Services.AddSingleton<PlayersViewModel>();
        builder.Services.AddSingleton<PlayersPage>();

        return builder.Build();
	}
}
