using Microsoft.Maui.Controls;

namespace Mobile_deliveryapplication.Views;

public partial class BestellingenPage : ContentPage
{
    public BestellingenPage()
    {
        InitializeComponent();
    }

    private async void OnVoltooienMetFotoClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                // Hier kun je eventueel de foto opslaan of uploaden

                await DisplayAlert("Succes", "Bestelling is gemarkeerd als voltooid met foto.", "OK");
                // Je zou hier ook kunnen updaten dat de bestelling voltooid is in je backend
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Kon geen foto maken: {ex.Message}", "OK");
        }
    }
}
