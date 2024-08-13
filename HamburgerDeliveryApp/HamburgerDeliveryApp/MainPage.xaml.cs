using System;
using System.Linq;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (!(currentPage is MainPage))
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void OnOrdersButtonClicked(object sender, EventArgs e)
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (!(currentPage is HistorialPedidos))
            {
                await Navigation.PushAsync(new HistorialPedidos());
            }
        }

        private async void OnUserButtonClicked(object sender, EventArgs e)
        {
            // Navega a la página de Usuario
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (!(currentPage is Usuario))
            {
                await Navigation.PushAsync(new Usuario()); // Asegúrate de que el constructor esté definido correctamente
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (!(currentPage is MainPage))
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void HamburPollo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HamburgesasdePollo());
        }
    }
}


