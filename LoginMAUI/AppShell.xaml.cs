using LoginMAUI.Views;

namespace LoginMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WeatherForecastPage), typeof(WeatherForecastPage));
        }
    }
}
