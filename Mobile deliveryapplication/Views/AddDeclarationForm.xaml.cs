using Plugin.Media.Abstractions; 
using Plugin.Media;
using Mobile_deliveryapplication.Models;

namespace Mobile_deliveryapplication.Views;


public partial class AddDeclarationForm : ContentPage
{
    private string _photoPath;

    public AddDeclarationForm()
    {
        InitializeComponent();
        InitializeMedia();
    }

    private async void InitializeMedia()
    {
        await CrossMedia.Current.Initialize();
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {

        FileResult Image = await MediaPicker.CapturePhotoAsync();
        string localFilePath = Path.Combine(FileSystem.AppDataDirectory, Image.FileName);

        using Stream sourceStream = await Image.OpenReadAsync();
        using FileStream localFileStream = File.OpenWrite(localFilePath);
        await sourceStream.CopyToAsync(localFileStream);

        _photoPath = localFilePath;
        PhotoPreview.Source = ImageSource.FromFile(localFilePath);
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {

        var result = await CrossMedia.Current.PickPhotoAsync();

        if (result != null)
        {
            _photoPath = result.Path;
            PhotoPreview.Source = ImageSource.FromFile(result.Path);
        }
    }
    private async void OnAddDeclarationClicked(object sender, EventArgs e)
    {
        
        var selectedType = Type.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(selectedType))
        {
            await DisplayAlert("Error", "Please select a type before proceeding.", "OK");
            return;
        }

        var declaratie = new Declaration
        {
            Datum = Datum.Date,
            ToegevoegdOp = DateTime.Now,
            Omschrijving = Omschrijving.Text,
            Bedrag = decimal.TryParse(Bedrag.Text, out var bedrag) ? bedrag : 0,
            Type = selectedType,
            FotoPad = _photoPath,
            Status = "In behandeling"
        };


        await Navigation.PushAsync(new DeclarationPage(declaratie));
    }
}