using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Repositories;
using BookStore.UI.HelperClasses;
using BookStore.UI.Pages.Admin;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.Authorization;

public partial class UserAuthPage : BasePage
{
    private RegisterUserAuthPage RegisterUserAuthPage { get; } = new RegisterUserAuthPage();
    
    private AdminAuthPage AdminAuthPage { get; } = new AdminAuthPage();
    
    private UserAuthViewModel PageViewModel { get; }

    public UserAuthPage()
    {
        InitializeComponent();

        DataContext = PageViewModel = new UserAuthViewModel();

        LoginTb.KeyDown += new KeyEventHandler((sender, e) =>
        {
            if (e.Key == Key.Enter)
                PasswordPb.Focus();
        });
        
        PasswordPb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                Login();
        };
    }

    public void Login()
    {
        var login = LoginTb.Text;
        var password = PasswordPb.Password;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Неккоректные данные!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var user = DataStore.Users.GetUserByLogin(login);

        if (user == null)
        {
            MessageBox.Show("Пользователь с таким логином не найден!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (user.Password != password)
        {
            MessageBox.Show("Неверный пароль", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        MessageBox.Show("Вы успешно вошли в систему!", "Info",
            MessageBoxButton.OK, MessageBoxImage.Information);

        LoginTb.Clear();
        PasswordPb.Clear();

        WindowsNavigation.AuthWindow.Hide();
        
        AppUser.SetInstance(user.Login, user.Password, user.Id);

        var userMainPage = PagesNavigation.UserMainPage;
        userMainPage.BooksFrame.Navigate(userMainPage.BooksListPage);
        WindowsNavigation.MainWindow.MainFrame.Navigate(userMainPage);

        WindowsNavigation.MainWindow.Show();
    }
    
    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        Login();
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.Navigate(RegisterUserAuthPage);
    }

    private void AdminModeBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.Navigate(AdminAuthPage);
    }
}