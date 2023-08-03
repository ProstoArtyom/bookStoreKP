using System.Windows;
using System.Windows.Controls;
using BookStore.UI.HelperClasses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Key = System.Windows.Input.Key;

namespace BookStore.UI.Pages.User;

public partial class UserMainPage : BasePage
{
    public ProfilePage ProfilePage { get; } = PagesNavigation.ProfilePage = new ProfilePage();

    public BooksListPage BooksListPage { get; } = PagesNavigation.BooksListPage = new BooksListPage();

    public CartPage CartPage { get; } = PagesNavigation.CartPage = new CartPage();

    public OrdersListPage OrdersPage { get; } = PagesNavigation.OrdersPage = new OrdersListPage();
    
    public UserMainPage()
    {
        InitializeComponent();
    }

    private void LogoutBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите выйти из учётной записи?", 
            "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;
        
        AppUser.SetInstance("", "", 0);
        
        WindowsNavigation.MainWindow.Hide();
        WindowsNavigation.AuthWindow.Show();
    }

    private void AccountBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(ProfilePage);
    }

    private void OrdersBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(OrdersPage);
    }

    private void CartBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(CartPage);
    }

    private void HomeBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(BooksListPage);
    }
}