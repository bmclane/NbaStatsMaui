using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        Sharpnado.TaskLoaderView.Initializer.Initialize(true); // logger enabled

        RegisterAppServices(builder.Services);

		return builder.Build();
	}

	private static void RegisterAppServices(IServiceCollection services)
	{
		services.AddSingleton<INbaApiService, NbaApiService>();
	}
}
