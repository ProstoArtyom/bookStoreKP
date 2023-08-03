using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.UI.Pages.User;

namespace BookStore.UI.Pages.Admin;

public partial class AdminOrdersListPage : BasePage
{
    public AdminOrdersListPage()
    {
        InitializeComponent();

        LoadOrders();
    }

    public void LoadOrders()
    {
        var orders = DataStore.Orders.GetOrders()
            .ToArray();
        
        OrdersDataGrid.ItemsSource = orders;
    }
    
    private void OrdersGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedOrder = OrdersDataGrid.SelectedItem as Order;
        if (selectedOrder == null)
            return;

        var orderPage = new OrderPage(selectedOrder);
        NavigationService!.Navigate(orderPage);
    }
}