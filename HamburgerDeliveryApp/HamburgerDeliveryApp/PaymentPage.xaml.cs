
using System;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
            BindingContext = new PaymentPageViewModel();
        }
        private async void RegresarCarro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddressPage());
        }
    }
}
