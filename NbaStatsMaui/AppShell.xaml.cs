using NbaStatsMaui.Views;

namespace NbaStatsMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent(); 
		Routing.RegisterRoute(nameof(GameDetailPage), typeof(GameDetailPage));
    }
}
