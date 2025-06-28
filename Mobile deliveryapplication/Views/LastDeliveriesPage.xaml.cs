using Mobile_deliveryapplication.API;
using Mobile_deliveryapplication.Models;
using Mobile_deliveryapplication.Services;

namespace Mobile_deliveryapplication.Views;

public partial class LastDeliveriesPage : ContentPage
{
    public LastDeliveriesPage()
    {
        InitializeComponent();
        LoadDeliveries();
    }

   private async void LoadDeliveries()
{
    try
    {
        var delivery = await ApiService.GetDeliveryHistoryAsync();
        IdLabel.Text = delivery.id.ToString();
        NameLabel.Text = delivery.name;
    }
    catch (Exception ex)
    {
        await DisplayAlert("Fout", $"Er ging iets mis: {ex.Message}", "OK");
    }
}
}