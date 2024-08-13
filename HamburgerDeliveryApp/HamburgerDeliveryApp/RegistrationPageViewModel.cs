using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace HamburgerDeliveryApp.ViewModels
{
    public class RegistrationPageViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public ICommand SaveUserCommand { get; }

        public RegistrationPageViewModel()
        {
            SaveUserCommand = new Command(OnSaveUser);
        }

        private async void OnSaveUser()
        {
            // Verificar que los campos requeridos no sean nulos o vacíos
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Crear un nuevo usuario con los datos del formulario
            var user = new User
            {
                Name = UserName,
                Email = Email,
                Phone = Phone,
                Birthdate = DateOfBirth,
                Address = Address
            };

            try
            {
                // Guardar el usuario en la base de datos
                await App.Database.SaveUserAsync(user);

                // Navegar a la página de Usuario pasando el usuario guardado
                await Application.Current.MainPage.Navigation.PushAsync(new Usuario(user));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al guardar el usuario: {ex.Message}\nDetalles: {ex.StackTrace}", "OK");
            }
        }

    }
}


