using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using HamburgerDeliveryApp.Models;
using System.Diagnostics;

namespace HamburgerDeliveryApp.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        // Propiedades del usuario
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }

        // Comandos para guardar y cerrar sesión
        public ICommand SaveCommand { get; }
        public ICommand LogoutCommand { get; }

        // Constructor que recibe un objeto User
        public UsuarioViewModel(User user)
        {
            if (user != null)
            {
                Name = user.Name;
                Email = user.Email;
                Phone = user.Phone;
                Birthdate = user.Birthdate;
                Address = user.Address;
            }
            else
            {
                // Manejar el caso en que el usuario sea null
                Name = "No disponible";
                Email = "No disponible";
                Phone = "No disponible";
                Birthdate = DateTime.MinValue;
                Address = "No disponible";
            }
            Debug.WriteLine($"Name: {Name}, Email: {Email}, Phone: {Phone}, Birthdate: {Birthdate}, Address: {Address}");

            // Inicializa los comandos
            SaveCommand = new Command(OnSave);
            LogoutCommand = new Command(OnLogout);
        }

        // Método para guardar los cambios (deberás implementar la lógica)
        private async void OnSave()
        {
            try
            {
                await Application.Current.MainPage.DisplayAlert("Guardado", "Los cambios han sido guardados.", "OK");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el guardado
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al guardar los cambios: {ex.Message}", "OK");
            }
        }

        // Método para cerrar sesión (deberás implementar la lógica)
        private async void OnLogout()
        {
            try
            {
                
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el cierre de sesión
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error al cerrar sesión: {ex.Message}", "OK");
            }
        }
    }
}



