
namespace NbaStatsMaui.Views;

public partial class PlayersPage : BaseContentPage
{
	PlayersViewModel ViewModel;

	public PlayersPage(PlayersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

}