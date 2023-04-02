namespace NbaStatsMaui.Views;

public partial class SchedulePage : BaseContentPage
{
	ScheduleViewModel ViewModel;

	public SchedulePage(ScheduleViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = ViewModel = viewModel;
    }

    private void CollectionViewExtended_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        dateCollectionView.ScrollTo(ViewModel.GetSelectedIndex(), -1, ScrollToPosition.Center, true);
    }
}