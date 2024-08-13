using HamburgerDeliveryApp;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

public class HamburgesasdePolloViewModel : BindableObject
{
    private readonly CartService _cartService;
    private readonly FavoriteService _favoriteService;
    private string _searchText;

    public ObservableCollection<Hamburger> Hamburgers { get; }
    public ObservableCollection<Hamburger> FilteredHamburgers { get; }

    public ICommand AddToCartCommand { get; }
    public ICommand ToggleFavoriteCommand { get; }
    public ICommand ViewFavoritesCommand { get; }
    public ICommand ViewCartCommand { get; }

    public double Total => _cartService.Total;

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
            FilterHamburgers();
        }
    }

    public HamburgesasdePolloViewModel()
    {
        _cartService = CartService.Instance;
        _favoriteService = FavoriteService.Instance;

        _cartService.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(CartService.Total))
            {
                OnPropertyChanged(nameof(Total));
            }
        };

        Hamburgers = new ObservableCollection<Hamburger>
        {
            new Hamburger { Name = "Hamburguesa de Pollo", Precio = 50.10, ImageUrl = "PolloS.png" },
            new Hamburger { Name = "Hamburguesa Doble Pollo", Precio = 78.30, ImageUrl = "PolloD.png" },
            new Hamburger { Name = "Hamburguesa Triple Pollo", Precio = 79.99, ImageUrl = "PolloT.png" },
            new Hamburger { Name = "Hamburguesa Pollo Delux", Precio = 50.10, ImageUrl = "PolloDL.png" },
            new Hamburger { Name = "Hamburguesa Pollo Crispy", Precio = 78.30, ImageUrl = "PolloCS.png" },
            new Hamburger { Name = "4 Nuggets", Precio = 79.99, ImageUrl = "cuatroNUG.png" },
            new Hamburger { Name = "10 Nuggets", Precio = 50.10, ImageUrl = "diezNUG.png" },
            new Hamburger { Name = "20 Nuggets", Precio = 78.30, ImageUrl = "diezNUG.png" },
    
        };

        FilteredHamburgers = new ObservableCollection<Hamburger>(Hamburgers);

        AddToCartCommand = new Command<Hamburger>(AddToCart);
        ToggleFavoriteCommand = new Command<Hamburger>(ToggleFavorite);
        ViewFavoritesCommand = new Command(ViewFavorites);
        ViewCartCommand = new Command(ViewCart);
    }

    private void AddToCart(Hamburger hamburger)
    {
        _cartService.AddToCart(hamburger);
    }

    private void ToggleFavorite(Hamburger hamburger)
    {
        _favoriteService.ToggleFavorite(hamburger);
    }

    private async void ViewFavorites()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new FavoritesPage(_favoriteService));
    }

    private async void ViewCart()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new CartPage(_cartService));
    }

    private void FilterHamburgers()
    {
        if (string.IsNullOrWhiteSpace(_searchText))
        {
            FilteredHamburgers.Clear();
            foreach (var hamburger in Hamburgers)
            {
                FilteredHamburgers.Add(hamburger);
            }
        }
        else
        {
            var filtered = Hamburgers.Where(h => h.Name.ToLower().Contains(_searchText.ToLower())).ToList();
            FilteredHamburgers.Clear();
            foreach (var hamburger in filtered)
            {
                FilteredHamburgers.Add(hamburger);
            }
        }
    }
}

