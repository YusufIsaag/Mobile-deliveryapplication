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
                Text = "Hallo met Johan, wat is de status van mijn bestelling?",
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

            if (input.Contains("bijna") || input.Contains("kom eraan"))
                return "Is goed, ik wacht wel!";
            if (input.Contains("aangekomen"))
                return "Top, ik kom eraan!";
            if (input.Contains("buren") || input.Contains("afleveren"))
                return "Ja hoor, geen probleem.";
            if (input.Contains("vertraging"))
                return "Geen probleem, neem je tijd.";
            if (input.Contains("onderweg"))
                return "Hoelang duurt het nog?";
            if (input.Contains("minuten"))
                return "Helemaal prima";
            if (input.Contains("deur"))
                return "Ik kom de deur nu open maken! …Èn moment!";
            if (input.Contains("geleverd"))
                return "Bedankt voor de levering!";

            return "Bedankt voor de update!";
        }

    }
}
