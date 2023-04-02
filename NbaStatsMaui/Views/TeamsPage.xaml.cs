namespace NbaStatsMaui.Views;

public partial class TeamsPage : BaseContentPage
{
    TeamsViewModel ViewModel;

    public TeamsPage(TeamsViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = ViewModel = viewModel;
    }
}