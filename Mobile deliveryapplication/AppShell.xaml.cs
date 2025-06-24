using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Mobile_deliveryapplication.Views;

namespace Mobile_deliveryapplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Account), typeof(Account));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //// 1. Vibrate (200ms)
            //if (Vibration.Default.IsSupported)
            //    Vibration.Default.Vibrate(200);

            //// 2. Show device info
            //var deviceInfo = $"Device: {DeviceInfo.Current.Model} {DeviceInfo.Manufacturer} ({DeviceInfo.Current.Platform})";

            //// 3. Check battery
            //var batteryInfo = Battery.Default.ChargeLevel * 100 + "%";

            //// 4. Get approximate location
            //Location location = null;
            //try
            //{
            //    location = await Geolocation.Default.GetLastKnownLocationAsync();
            //}
            //catch { /* Ignore errors */ }

            //// 5. Toggle flashlight (if available)
            //try
            //{
                
            //        await Flashlight.Default.TurnOnAsync();
            //        await Task.Delay(1000); // Keep on for 300ms
            //        await Flashlight.Default.TurnOffAsync();
                
            //}
            //catch { /* Ignore errors */ }

            //// Show alert with collected info
            //await DisplayAlert("Device Features",
            //    $"{deviceInfo}\n" +
            //    $"Battery: {batteryInfo}\n" +
            //    (location != null ? $"Location: {location.Latitude}, {location.Longitude}" : ""),
            //    "OK");

            
            await Shell.Current.GoToAsync("/Account");
        
        }
    }
}