using System.Linq;
using System;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class CartPage : ContentPage
    {
        public CartPage(CartService cartService)
        {
            InitializeComponent();
            BindingContext = new CartPageViewModel();
        }
        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            // Obtener la página actual en la pila de navegación
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            // Si la página actual no es MainPage, navega a MainPage
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

    }
}


