namespace Mobile_deliveryapplication.Views;

public partial class DeclarationPage : ContentPage
{
	public DeclarationPage()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddDeclarationForm), typeof(AddDeclarationForm));
	}

    private async void AddDeclaration_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("/AddDeclarationForm");
    }
}