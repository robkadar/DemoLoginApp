using LoginMAUI.Services;
using LoginMAUI.ViewModels;
using LoginMAUI.Views;
using Microsoft.Extensions.Logging;

namespace LoginMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
            {
#if ANDROID
                return new AndroidHttpMessageHandler();
#else
                return null!;
#endif

            });

            builder.Services.AddHttpClient("custom-httpclient", httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7052" : "https://localhost:7052";
                httpClient.BaseAddress = new Uri(baseAddress);
            }).ConfigureHttpMessageHandlerBuilder(configBuilder =>
            {
                var platformMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                configBuilder.PrimaryHandler = platformMessageHandler.GetHttpMessageHandler();
            });

            builder.Services.AddSingleton<ClientService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<WeatherForecastPage>();
            builder.Services.AddSingleton<WeatherForecastViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
