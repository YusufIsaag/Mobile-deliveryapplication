using CommunityToolkit.Maui;

namespace Mobile_deliveryapplication.Views;

public partial class MainPage : ContentPage
{
    private void OnAccountButtonClicked(object sender, EventArgs e)
    {
        // Bijvoorbeeld: navigeren naar een profielpagina
        Console.WriteLine("Account-knop geklikt!");
    }

    public MainPage()
        {
        InitializeComponent();
        }
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Continue initializing your .NET MAUI App here

            return builder.Build();
        }
    }


}
