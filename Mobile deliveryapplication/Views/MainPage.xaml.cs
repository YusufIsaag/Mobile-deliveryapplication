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

    private async void OnLastDeliveriesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LastDeliveriesPage());
    }

    private async void OnViewStatusClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StatusPage());
    }
}