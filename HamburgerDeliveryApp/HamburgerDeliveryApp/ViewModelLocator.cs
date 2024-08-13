using System;
using System.Collections.Generic;
using System.Text;

namespace HamburgerDeliveryApp
{
    public static class ViewModelLocator
    {
        static ViewModelLocator()
        {
            // Aquí puedes registrar tus ViewModels con un contenedor de dependencias si usas uno
            // Ejemplo con un contenedor ficticio:
            // Container.Register<AddressPageViewModel>();
            // Container.Register<PaymentPageViewModel>();
        }

        public static AddressPageViewModel AddressViewModel { get; } = new AddressPageViewModel();
        public static PaymentPageViewModel PaymentViewModel { get; } = new PaymentPageViewModel();
    }
}
