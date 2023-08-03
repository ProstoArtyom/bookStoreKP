using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.UI.HelperClasses;

namespace BookStore.UI.Pages.Admin;

public partial class AdminAuthPage : BasePage
{
    public AdminAuthPage()
    {
        InitializeComponent();

        PasswordPb.KeyDown += delegate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Login();
        };
    }

    private void Login()
    {
        var password = Properties.Settings.Default.AdminPassword;
        var input = PasswordPb.Password;
        if (password != input)
        {
            MessageBox.Show("Неверный пароль!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        MessageBox.Show("Вы успешно вошли в систему!", "Info",
            MessageBoxButton.OK, MessageBoxImage.Information);
        
        PasswordPb.Clear();
        
        WindowsNavigation.AuthWindow.Hide();
        NavigationService!.GoBack();

        var adminMainPage = PagesNavigation.AdminMainPage;
        adminMainPage.BooksFrame.Navigate(adminMainPage.BooksListPage);
        WindowsNavigation.MainWindow.MainFrame.Navigate(adminMainPage);

        WindowsNavigation.MainWindow.Show();
    }
    
    private void LoginBtn_Click(object sender, RoutedEventArgs e)
    {
        Login();
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
}