namespace Mobile_deliveryapplication;

public partial class StatusPage : ContentPage
{
    private int _currentStep = 0;
    private readonly string[] _statusList = new[]
    {
        "Aangenomen",
        "Onderweg",
        "Bijna aangekomen",
        "Afgeleverd"
    };

    public StatusPage()
    {
        InitializeComponent();
        UpdateStatus();
    }

    private void OnNextStepClicked(object sender, EventArgs e)
    {
        if (_currentStep < _statusList.Length - 1)
        {
            _currentStep++;
            UpdateStatus();
        }
        else
        {
            DisplayAlert("Klaar", "Het pakket is al afgeleverd.", "OK");
        }
    }

    private void UpdateStatus()
    {
        StatusLabel.Text = $"Status: {_statusList[_currentStep]}";
        StatusProgress.Progress = (double)_currentStep / (_statusList.Length - 1);
    }
}
