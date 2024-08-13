using HamburgerDeliveryApp;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

public class MainPageViewModel : BindableObject
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

    public MainPageViewModel()
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
            new Hamburger { Name = "Hamburguesa de Queso", Precio = 50.10, ImageUrl = "HamQueso.png" },
            new Hamburger { Name = "Hamburguesa Doble Queso", Precio = 78.30, ImageUrl = "HamQuesoD.png" },
            new Hamburger { Name = "Hamburguesa Triple Queso", Precio = 79.99, ImageUrl = "HamQuesoT.png" },
            new Hamburger { Name = "Hamburguesa BBQ", Precio = 50.10, ImageUrl = "HamBB.png" },
            new Hamburger { Name = "Hamburguesa Doble BBQ", Precio = 78.30, ImageUrl = "HamBBD.png" },
            new Hamburger { Name = "Hamburguesa Triple BBQ", Precio = 79.99, ImageUrl = "HamBBT.png" },
            new Hamburger { Name = "Hamburguesa Gourmet", Precio = 50.10, ImageUrl = "HamCBO.png" },
            new Hamburger { Name = "Hamburguesa Doble Gourmet", Precio = 78.30, ImageUrl = "HamCBOD.png" },
            new Hamburger { Name = "Hamburguesa Triple Gourmet", Precio = 79.99, ImageUrl = "HamCBOT.png" },
            new Hamburger { Name = "Hamburguesa Clasica", Precio = 50.10, ImageUrl = "HamTD.png" },
            new Hamburger { Name = "Hamburguesa Triple Clasica", Precio = 78.30, ImageUrl = "HamTDT.png" },
            new Hamburger { Name = "Hamburguesa Deluxe Clasica", Precio = 79.99, ImageUrl = "HamTT.png" }
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





















