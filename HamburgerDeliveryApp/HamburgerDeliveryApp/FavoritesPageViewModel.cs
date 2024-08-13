using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HamburgerDeliveryApp
{
    public class FavoritesPageViewModel : BindableObject
    {
        private readonly FavoriteService _favoriteService;

        public ObservableCollection<Hamburger> FavoriteItems => _favoriteService.FavoriteItems;

        public FavoritesPageViewModel(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
    }
}


