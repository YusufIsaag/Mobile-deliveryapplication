using System.Xml;
using Mobile_deliveryapplication.API;
using Mobile_deliveryapplication.Models;
using Mobile_deliveryapplication.Services;

namespace Mobile_deliveryapplication.Views
{
    public partial class LastDeliveriesPage : ContentPage
    {
        public LastDeliveriesPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private async void LoadOrders()
        {
            try
            {
                var orderIds = new List<int> { 1, 2, 3, 4, 5, 6 };
                var orders = new List<OrderModel>();

                foreach (var id in orderIds)
                {
                    var order = await ApiService.GetOrderAsync(id);
                    if (order != null)
                    {
                        orders.Add(order);
                    }
                }

                if (orders.Count == 0)
                {
                    await DisplayAlert("Info", "Geen orders gevonden.", "OK");
                    return;
                }

                OrdersList.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fout", $"Er ging iets mis: {ex.Message}", "OK");
            }
        }
    }

}
  