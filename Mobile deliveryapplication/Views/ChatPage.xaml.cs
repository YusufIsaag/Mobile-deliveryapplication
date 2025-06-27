using System.Collections.ObjectModel;
using Mobile_deliveryapplication.Models;


namespace Mobile_deliveryapplication.Views
{
    public partial class ChatPage : ContentPage
    {
        public ObservableCollection<ChatMessage> Messages { get; set; } = new();

        public ChatPage()
        {
            InitializeComponent();
            BindingContext = this;

            Messages.Add(new ChatMessage
            {
                Text = "Wat is de status van mijn bestelling?",
                IsUser = false
            });
        }

        private void OnSendClicked(object sender, EventArgs e)
        {
            var text = MessageEntry.Text?.Trim();
            if (string.IsNullOrEmpty(text)) return;

            Messages.Add(new ChatMessage { Text = text, IsUser = true });
            MessageEntry.Text = string.Empty;

            Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                var antwoord = GenereerAntwoord(text);
                Messages.Add(new ChatMessage { Text = antwoord, IsUser = false });
                return false;
            });
        }


        private string GenereerAntwoord(string input)
        {
            input = input.ToLower();

            if (input.Contains("bijna") || input.Contains("kom eraan") || input.Contains("zo daar"))
                return "Is goed, ik wacht wel!";

            if (input.Contains("aangekomen") || input.Contains("ben er") || input.Contains("ik sta") || input.Contains("ik ben er"))
                return "Top, ik kom eraan!";

            if (input.Contains("buren") || input.Contains("afleveren") || input.Contains("mag bij de buren") || input.Contains("bij buren"))
                return "Ja hoor, geen probleem.";

            if (input.Contains("vertraging") || input.Contains("later") || input.Contains("ik red het niet") || input.Contains("verlaat"))
                return "Geen probleem, neem je tijd.";

            if (input.Contains("hallo") || input.Contains("hey") || input.Contains("hi"))
                return "Hoi!?";

            if (input.Contains("onderweg") || input.Contains("ben onderweg") || input.Contains("kom eraan"))
                return "Hoelang duurt het nog ongeveer?";

            if (input.Contains("minuut") || input.Contains("zo daar") || input.Contains("minuten"))
                return "Helemaal prima!";

            if (input.Contains("deur") || input.Contains("open") || input.Contains("deur open"))
                return "Ik kom de deur nu openmaken! Één moment.";

            if (input.Contains("geleverd") || input.Contains("pakket bezorgd") || input.Contains("klaar"))
                return "Bedankt voor de levering!";

            if (input.Contains("adres") || input.Contains("waar moet ik zijn") || input.Contains("locatie"))
                return "Het adres is Roselierlaan 82.";

            if (input.Contains("druk") || input.Contains("veel te doen") || input.Contains("drukte"))
                return "Snap ik! Doe rustig aan.";

            if (input.Contains("moeilijk te vinden") || input.Contains("kan het niet vinden"))
                return "Het huis heeft een rode deur en een zwarte auto voor de deur.";

            if (input.Contains("tot zo") || input.Contains("tot straks"))
                return "Tot zo!";

            return "Bedankt voor de update!";
        }

    }
}
