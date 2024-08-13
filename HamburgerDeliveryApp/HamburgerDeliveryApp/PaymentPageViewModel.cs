using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class PaymentMethod
    {
        public string MethodName { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
    }

    public class PaymentPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; }
        public Command AddPaymentMethodCommand { get; }
        public Command SaveCommand { get; }

        public PaymentPageViewModel()
        {
            PaymentMethods = new ObservableCollection<PaymentMethod>
            {
                new PaymentMethod { ImageUrl = "dollar.png", MethodName = "Efectivo", UserName = "" }
            };

            AddPaymentMethodCommand = new Command(AddPaymentMethod);
            SaveCommand = new Command(Save);

            MessagingCenter.Subscribe<AddCreditCardViewModel, CreditCard>(this, "AddCard", (sender, card) =>
            {
                PaymentMethods.Add(new PaymentMethod
                {
                    MethodName = card.CardType,
                    UserName = $"{card.CardHolder} **** {card.MaskedCardNumber}",
                    ImageUrl = "credit_card_image.png"  // Imagen predeterminada para la tarjeta
                   
                });
            });
        }

        private async void AddPaymentMethod()
        {
            // Lógica para agregar un nuevo método de pago
            await Application.Current.MainPage.Navigation.PushAsync(new SelectPaymentMethodPage());
        }

        private async void Save()
        {
            // Lógica para guardar el método de pago seleccionado
            await Application.Current.MainPage.DisplayAlert("Éxito", "Método de pago guardado con éxito.", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


