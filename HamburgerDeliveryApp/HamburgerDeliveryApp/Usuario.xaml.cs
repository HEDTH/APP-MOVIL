using HamburgerDeliveryApp.Models;
using HamburgerDeliveryApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class Usuario : ContentPage
    {
        private User user; // Asegúrate de definir el user en esta clase.

        public Usuario()
        {
            InitializeComponent();
            if (user == null)
            {
                // Puedes manejar el caso en que `user` sea null, por ejemplo, redirigiendo a una página de error
                Application.Current.MainPage.DisplayAlert("Error", "No se proporcionó un usuario válido.", "OK");
                return;
            }

            BindingContext = new UsuarioViewModel(user);
        }

        public Usuario(User currentUser)
        {
            InitializeComponent();
            // Asigna el currentUser a una propiedad o úsalo como lo necesites
            BindingContext = new UsuarioViewModel(user);
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

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
