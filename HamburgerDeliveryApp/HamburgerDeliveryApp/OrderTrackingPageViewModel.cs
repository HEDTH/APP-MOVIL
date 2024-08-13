using System;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class OrderTrackingPageViewModel : BindableObject
    {
        private string _estimatedDeliveryTime;

        public string EstimatedDeliveryTime
        {
            get => _estimatedDeliveryTime;
            set
            {
                _estimatedDeliveryTime = value;
                OnPropertyChanged();
            }
        }

        public OrderTrackingPageViewModel()
        {
            // Simulate fetching estimated delivery time
            EstimatedDeliveryTime = "Tiempo estimado de entrega: 30 minutos";
        }
    }
}

