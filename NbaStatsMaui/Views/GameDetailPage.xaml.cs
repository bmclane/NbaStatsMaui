namespace NbaStatsMaui.Views;

public partial class GameDetailPage : BaseContentPage
{
	GameDetailViewModel ViewModel;
	public GameDetailPage(GameDetailViewModel gameDetailViewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = gameDetailViewModel;
	}
}