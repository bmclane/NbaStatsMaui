namespace NbaStatsMaui.Controls;

public partial class SearchBar : ContentView
{
    public event EventHandler<TextChangedEventArgs> TextChanged;

    public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(SearchBar), string.Empty);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(SearchBar), string.Empty, BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public SearchBar()
	{
		InitializeComponent();
	}

    private void Editor_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
        if(string.IsNullOrEmpty(Text))
            Clear.IsVisible = false;
        else
            Clear.IsVisible = true;
    }

    private void Clear_Tapped(object sender, TappedEventArgs e)
    {
        Text = string.Empty;
    }
}