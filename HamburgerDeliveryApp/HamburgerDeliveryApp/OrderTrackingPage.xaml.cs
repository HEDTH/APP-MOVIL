using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class OrderTrackingPage : ContentPage
    {
        public OrderTrackingPage()
        {
            InitializeComponent();
            BindingContext = new OrderTrackingPageViewModel();
        }
    }
}
