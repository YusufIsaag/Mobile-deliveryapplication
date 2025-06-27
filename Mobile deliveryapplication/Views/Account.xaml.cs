namespace Mobile_deliveryapplication.Views;

public partial class Account : ContentPage
{
    public Account()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DeclarationPage), typeof(DeclarationPage));
    }

    private async void Declartiesbutton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/DeclarationPage");
    }

}
