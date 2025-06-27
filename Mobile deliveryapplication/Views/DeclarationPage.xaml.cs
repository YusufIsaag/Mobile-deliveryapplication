using Mobile_deliveryapplication.Models;

namespace Mobile_deliveryapplication.Views;

public partial class DeclarationPage : ContentPage
{
    private List<Declaration> declaraties = new();

    public DeclarationPage()
    {
        InitializeComponent();
        DeclaratiesListView.ItemsSource = declaraties; // koppel lijst
        Routing.RegisterRoute(nameof(AddDeclarationForm), typeof(AddDeclarationForm));

        // ?? Eventhandler toevoegen voor selectie
        DeclaratiesListView.ItemSelected += (s, e) =>
        {
            if (e.SelectedItem is Declaration declaratie)
            {
                DisplayAlert("Declaratie", $"{declaratie.Type} op {declaratie.Datum:dd-MM-yyyy}\nBedrag: €{declaratie.Bedrag}\nStatus: {declaratie.Status}", "OK");
                // Deselecteren zodat je opnieuw kunt klikken
                DeclaratiesListView.SelectedItem = null;
            }
        };
    }

    // ? Tweede constructor buiten de eerste constructor
    public DeclarationPage(Declaration nieuweDeclaratie) : this()
    {
        nieuweDeclaratie.Status = "In behandeling";
        declaraties.Add(nieuweDeclaratie);
        DeclaratiesListView.ItemsSource = null; // reset
        DeclaratiesListView.ItemsSource = declaraties;
    }

    private async void AddDeclaration_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/AddDeclarationForm");
    }
}
