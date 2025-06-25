namespace Mobile_deliveryapplication.Views;

public partial class AddDeclarationForm : ContentPage
{
	public AddDeclarationForm()
	{
		InitializeComponent();
	}

    private async void OnAddPhotoClicked(object sender, EventArgs e)
    {
        await MediaPicker.CapturePhotoAsync();
        
    }

}