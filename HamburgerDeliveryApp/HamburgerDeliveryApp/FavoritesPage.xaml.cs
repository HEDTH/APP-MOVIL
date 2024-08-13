using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage(FavoriteService favoriteService)
        {
            InitializeComponent();
            BindingContext = new FavoritesPageViewModel(favoriteService);
        }
    }
}

