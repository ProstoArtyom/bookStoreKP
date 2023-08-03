using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;

namespace BookStore.UI.Pages.User;

public partial class OrdersListPage : BasePage
{
    public OrdersListPage()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var orders = DataStore.Orders.GetOrders(AppUser.Instance.AccountId)
            .ToArray();

        if (orders.Length == 0)
        {
            OrderDataGrid.Visibility = Visibility.Collapsed;
            OrdersStatusLbl.Visibility = Visibility.Visible;
        }
        else
        {
            OrderDataGrid.ItemsSource = orders;
            OrderDataGrid.Visibility = Visibility.Visible;
            OrdersStatusLbl.Visibility = Visibility.Collapsed;
        }
    }

    private void OrderDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedOrder = OrderDataGrid.SelectedItem as Order;
        if (selectedOrder == null)
            return;

        var orderPage = new OrderPage(selectedOrder);
        NavigationService!.Navigate(orderPage);
    }
}