using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HamburgerDeliveryApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HamburgesasdePollo : ContentPage
	{
		public HamburgesasdePollo ()
		{
			InitializeComponent ();
            BindingContext = new HamburgesasdePolloViewModel();

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
            
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            if (!(currentPage is HamburgesasdePollo))
            {
                await Navigation.PushAsync(new HamburgesasdePollo());
            }
        }
    }
}