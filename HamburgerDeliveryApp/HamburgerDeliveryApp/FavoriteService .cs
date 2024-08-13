using HamburgerDeliveryApp;
using System;
using System.Collections.ObjectModel;

public class FavoriteService
{
    private static readonly Lazy<FavoriteService> lazy = new Lazy<FavoriteService>(() => new FavoriteService());

    public static FavoriteService Instance => lazy.Value;

    private ObservableCollection<Hamburger> _favoriteItems;


    public ObservableCollection<Hamburger> FavoriteItems
    {
        get => _favoriteItems;
        set => _favoriteItems = value;
    }

    private FavoriteService()
    {
        FavoriteItems = new ObservableCollection<Hamburger>();
    }

    public void ToggleFavorite(Hamburger hamburger)
    {
        if (FavoriteItems.Contains(hamburger))
        {
            FavoriteItems.Remove(hamburger);
        }
        else
        {
            FavoriteItems.Add(hamburger);
        }
    }
}


