using HamburgerDeliveryApp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

public class CartService : INotifyPropertyChanged
{
    private static CartService _instance;
    public static CartService Instance => _instance ?? (_instance = new CartService());

    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<CartItem> _cartItems;
    public ObservableCollection<CartItem> CartItems
    {
        get => _cartItems;
        set
        {
            _cartItems = value;
            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(Total));
        }
    }

    public double Total => _cartItems.Sum(item => item.Hamburger.Precio * item.Quantity);

    public CartService()
    {
        _cartItems = new ObservableCollection<CartItem>();
        _cartItems.CollectionChanged += (sender, args) =>
        {
            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(Total));
        };
    }

    public void AddToCart(Hamburger hamburger)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.Hamburger.Name == hamburger.Name);
        if (existingItem != null)
        {
            existingItem.Quantity++;
            NotifyCartChanged();
        }
        else
        {
            _cartItems.Add(new CartItem { Hamburger = hamburger, Quantity = 1 });
            NotifyCartChanged();
        }
    }

    public void RemoveFromCart(Hamburger hamburger)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.Hamburger.Name == hamburger.Name);
        if (existingItem != null)
        {
            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
            }
            else
            {
                _cartItems.Remove(existingItem);
            }
            NotifyCartChanged();
        }
    }

    private void NotifyCartChanged()
    {
        OnPropertyChanged(nameof(CartItems));
        OnPropertyChanged(nameof(Total));
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class CartItem : INotifyPropertyChanged
{
    private int _quantity;
    public Hamburger Hamburger { get; set; }
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
    }

    public double TotalPrice => Hamburger.Precio * Quantity;

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}








