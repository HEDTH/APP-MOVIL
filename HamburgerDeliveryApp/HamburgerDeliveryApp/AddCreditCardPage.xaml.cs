using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HamburgerDeliveryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCreditCardPage : ContentPage
    {
        public AddCreditCardPage()
        {
            InitializeComponent();
            BindingContext = new AddCreditCardViewModel();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    public class AddCreditCardViewModel : INotifyPropertyChanged
    {
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public Command SaveCommand { get; }

        public AddCreditCardViewModel()
        {
            SaveCommand = new Command(Save);
        }

        private async void Save()
        {
            // Lógica para guardar la tarjeta
            var card = new CreditCard
            {
                CardNumber = CardNumber,
                FirstName = FirstName,
                LastName = LastName,
                ExpirationDate = ExpirationDate,
                CVV = CVV
            };

            MessagingCenter.Send(this, "AddCard", card);

            await Application.Current.MainPage.DisplayAlert("Éxito", "Tarjeta guardada con éxito.", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }

        public string MaskedCardNumber => $"**** **** **** {CardNumber?.Substring(CardNumber.Length - 4)}";
        public string CardType => "Crédito";  // O puedes usar lógica para determinar el tipo de tarjeta
        public string CardHolder => $"{FirstName} {LastName}";
    }
}




