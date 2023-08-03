using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using BookStore.Storage.Repositories;

namespace BookStore.UI.Pages.Authorization;

public partial class RegisterUserAuthPage : BasePage
{
    public RegisterUserAuthPage()
    {
        InitializeComponent();
        
        LoginTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                EmailTb.Focus();
        };

        EmailTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                PasswordTb.Focus();
        };
        
        PasswordTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                ConfirmPasswordTb.Focus();
        };

        ConfirmPasswordTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                Register();
        };
    }

    private void Register()
    {
        var worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = true;
        worker.DoWork += (o, args) =>
        {
            var backgroundWorker = (BackgroundWorker)o!;
            
            var login = string.Empty;
            var password = string.Empty;
            var confirmPassword = string.Empty;
            var email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                login = LoginTb.Text;
                password = PasswordTb.Password;
                confirmPassword = ConfirmPasswordTb.Password;
                email = EmailTb.Text;
            });
            
            if (!IsStringValid(login)
                || !IsEmailValid(email)
                || !IsStringValid(password)
                || !(IsStringValid(confirmPassword) && password == confirmPassword))
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Некорректные данные!", "Error", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                });
                backgroundWorker.CancelAsync();
                return;
            }

            IBookStoreAppRepository dataStore = new BookStoreAppRepository();
            
            if (dataStore.Users.IsLoginExists(login))
            {
                Dispatcher.Invoke(() => MessageBox.Show("Пользователь с таким логином уже существует!", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                backgroundWorker.CancelAsync();
                return;
            }

        
            if (dataStore.Profiles.IsEmailUsed(email, 0))
            {
                Dispatcher.Invoke(() => MessageBox.Show("Данная почта уже используется другим пользователем!", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error));
                backgroundWorker.CancelAsync();
                return;
            }
            
            dataStore.Users.CreateUser(login, password, email);

            Dispatcher.Invoke(() =>
            {
                MessageBox.Show("Вы успешно зарегистрировали новую учётную запись.", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                
                GoBackPage();
            });
        };
        worker.RunWorkerAsync();
    }
    
    private void RegisterBtn_Click(object sender, RoutedEventArgs e)
    {
        Register();
    }
    
    private void ReturnBtn_Click(object sender, RoutedEventArgs e)
    {
        GoBackPage();
    }

    private void GoBackPage()
    {
        LoginTb.Clear();
        EmailTb.Clear();
        PasswordTb.Clear();
        ConfirmPasswordTb.Clear();

        NavigationService!.GoBack();
    }
    
    private bool IsEmailValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    
    private bool IsStringValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
}