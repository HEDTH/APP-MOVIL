using HamburgerDeliveryApp.Models;
using HamburgerDeliveryApp;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class OrderHistoryViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Order> _orders;

    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged(nameof(Orders));
        }
    }

    public OrderHistoryViewModel(int userId)
    {
        LoadOrders(userId);
    }

    private async void LoadOrders(int userId)
    {
        var orders = await App.Database.GetOrdersByUserAsync(userId);
        Orders = new ObservableCollection<Order>(orders);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
