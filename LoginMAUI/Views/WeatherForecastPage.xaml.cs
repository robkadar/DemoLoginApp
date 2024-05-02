using LoginMAUI.ViewModels;

namespace LoginMAUI.Views;

public partial class WeatherForecastPage : ContentPage
{
    public WeatherForecastPage(WeatherForecastViewModel weatherForecastViewModel)
    {
        InitializeComponent();
        BindingContext = weatherForecastViewModel;
    }
}