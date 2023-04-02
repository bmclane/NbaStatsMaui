namespace NbaStatsMaui.Models;

public partial class ModelDate : ObservableObject
{
    [ObservableProperty]
    public bool isSelected;

    public DateTime Date { get; set; }

    public ModelDate(DateTime date)
    {
        Date = date;
    }

}
