using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HamburgerDeliveryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPaymentMethodPage : ContentPage
    {
        public SelectPaymentMethodPage()
        {
            InitializeComponent();
            BindingContext = new SelectPaymentMethodPageViewModel();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void AddPaymentMethod()
        {
            // Navegar a la página de selección de método de pago
            await Application.Current.MainPage.Navigation.PushAsync(new SelectPaymentMethodPage());
        }
       
    }
}



