using Microsoft.Maui.Media;
using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace Mobile_deliveryapplication.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

  

    // Camera-functie: foto maken en opslaan
    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            FileResult photo = await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                await sourceStream.CopyToAsync(localFileStream);

                await DisplayAlert("Bevestiging", $"Foto opgeslagen: {localFilePath}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Kon geen foto maken: {ex.Message}", "OK");
        }
    }

    // Navigatie naar StatusPage
    private async void OnViewStatusClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StatusPage());
    }
}

