using System.Windows;
using System.Windows.Controls;
using BookStore.UI.HelperClasses;
using BookStore.UI.Pages.User;

namespace BookStore.UI.Pages.Admin;

public partial class AdminMainPage : BasePage
{
    public AdminBooksListPage BooksListPage { get; } = new();

    public AdminAccountsListPage AccountsListPage { get; } = PagesNavigation.AccountsListPage = new();

    public AdminOrdersListPage OrdersListPage { get; } = PagesNavigation.AdminOrdersListPage = new();
    
    public AdminAnalysisPage AnalysisPage { get; } = PagesNavigation.AdminAnalysisPage = new();
    
    public AdminAddBookPage AddBookPage { get; } = new();
    
    public AdminMainPage()
    {
        InitializeComponent();

        PagesNavigation.AdminBooksListPage = BooksListPage;
    }

    private void AnalysisBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(AnalysisPage);
    }

    private void OrdersBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(OrdersListPage);
    }

    private void AccountsBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(AccountsListPage);
    }

    private void HomeBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(BooksListPage);
    }

    private void AddBookBtn_Click(object sender, RoutedEventArgs e)
    {
        BooksFrame.Navigate(AddBookPage);
    }
    
    private void LogoutBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите выйти из учётной записи?", 
            "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        WindowsNavigation.MainWindow.Hide();
        WindowsNavigation.AuthWindow.Show();
    }
}