using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class CartPageViewModel : BindableObject
    {
        private readonly CartService _cartService;

        public ObservableCollection<CartItem> CartItems => _cartService.CartItems;
        public double Total => _cartService.Total;

        public ICommand RemoveFromCartCommand { get; }
        public ICommand CheckoutCommand { get; }

        public CartPageViewModel()
        {
            _cartService = CartService.Instance;

            _cartService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CartService.Total))
                {
                    OnPropertyChanged(nameof(Total));
                }
                if (args.PropertyName == nameof(CartService.CartItems))
                {
                    OnPropertyChanged(nameof(CartItems));
                }
            };

            RemoveFromCartCommand = new Command<Hamburger>(RemoveFromCart);
            CheckoutCommand = new Command(Checkout);
        }

        private void RemoveFromCart(Hamburger hamburger)
        {
            _cartService.RemoveFromCart(hamburger);
        }

        private async void Checkout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddressPage());
        }
    }
}








