using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class AddressPageViewModel : INotifyPropertyChanged
    {
        private CartService _cartService;

        public ObservableCollection<CartItem> CartItems => _cartService.CartItems;

        public int CartItemsHeight => CartItems.Count * 100; // Aproximadamente 100 unidades de altura por item

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _references;
        public string References
        {
            get => _references;
            set
            {
                _references = value;
                OnPropertyChanged(nameof(References));
            }
        }

        private string _couponCode;
        public string CouponCode
        {
            get => _couponCode;
            set
            {
                _couponCode = value;
                OnPropertyChanged(nameof(CouponCode));
            }
        }

        private PaymentMethod _selectedPaymentMethod;
        public PaymentMethod SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                _selectedPaymentMethod = value;
                OnPropertyChanged(nameof(SelectedPaymentMethod));
            }
        }

        private bool _isPrioritySelected;
        public bool IsPrioritySelected
        {
            get => _isPrioritySelected;
            set
            {
                _isPrioritySelected = value;
                OnPropertyChanged(nameof(IsPrioritySelected));
                OnPropertyChanged(nameof(IsBasicSelected));
                OnPropertyChanged(nameof(PriorityButtonColor));
                OnPropertyChanged(nameof(BasicButtonColor));
            }
        }

        public bool IsBasicSelected => !IsPrioritySelected;

        public Color PriorityButtonColor => IsPrioritySelected ? Color.FromHex("#FFCA1A") : Color.Transparent;
        public Color BasicButtonColor => IsBasicSelected ? Color.FromHex("#FFCA1A") : Color.Transparent;

        public double Total => _cartService.Total;

        public Command ApplyCouponCommand { get; }
        public Command NextCommand { get; }
        public Command ChangeAddressCommand { get; }
        public Command ChangePaymentMethodCommand { get; }
        public Command SelectPriorityDeliveryCommand { get; }
        public Command SelectBasicDeliveryCommand { get; }

        public AddressPageViewModel()
        {
            _cartService = CartService.Instance;
            ApplyCouponCommand = new Command(ApplyCoupon);
            NextCommand = new Command(OnNext);
            ChangeAddressCommand = new Command(OnChangeAddress);
            ChangePaymentMethodCommand = new Command(OnChangePaymentMethod);
            SelectPriorityDeliveryCommand = new Command(SelectPriorityDelivery);
            SelectBasicDeliveryCommand = new Command(SelectBasicDelivery);
            _cartService.PropertyChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(CartItems));
                OnPropertyChanged(nameof(CartItemsHeight));
                OnPropertyChanged(nameof(Total));
            };

            MessagingCenter.Subscribe<PaymentPageViewModel, PaymentMethod>(this, "PaymentMethodSelected", (sender, paymentMethod) =>
            {
                SelectedPaymentMethod = paymentMethod;
            });
        }

        private void ApplyCoupon()
        {
            // Lógica para aplicar el cupón
        }

        private void OnNext()
        {
            // Lógica para el siguiente paso
        }

        private void OnChangeAddress()
        {
            // Lógica para cambiar la dirección
        }

        private bool _isNavigating = false;
        private async void OnChangePaymentMethod()
        {
            if (!_isNavigating)
            {
                _isNavigating = true;
                await Application.Current.MainPage.Navigation.PushAsync(new PaymentPage());
                _isNavigating = false;
            }
        }

        private void SelectPriorityDelivery()
        {
            IsPrioritySelected = true;
        }

        private void SelectBasicDelivery()
        {
            IsPrioritySelected = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}






