using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class SelectPaymentMethodPageViewModel : INotifyPropertyChanged
    {
        private string _selectedPaymentMethod;
        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                _selectedPaymentMethod = value;
                OnPropertyChanged(nameof(SelectedPaymentMethod));
            }
        }
        public Command SelectPaymentMethodCommand { get; }


        private void OnSelectPaymentMethod(string paymentMethod)
        {
            SelectedPaymentMethod = paymentMethod;
            // Navegar de regreso a la pantalla de hacer pedido o realizar cualquier otra acción necesaria
            Application.Current.MainPage.Navigation.PopAsync();
        }
        public Command AddCreditCardCommand { get; }
        public Command UsePayPalCommand { get; }

        public SelectPaymentMethodPageViewModel()
        {
            AddCreditCardCommand = new Command(OnAddCreditCard);
            UsePayPalCommand = new Command(UsePayPal);
        }

        private async void OnAddCreditCard()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddCreditCardPage());
        }

        private void UsePayPal()
        {
            // Lógica para usar PayPal
            var paypalUrl = "https://www.paypal.com/signin";
            Device.OpenUri(new Uri(paypalUrl));

            // Aquí puedes agregar la lógica adicional para guardar la selección del método de pago
            // y navegar de regreso a la página del carrito una vez que el usuario haya completado la autenticación en PayPal.
            // Esperar hasta que el usuario regrese de PayPal (esto puede ser mejorado con un servicio de notificación o similar).
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


