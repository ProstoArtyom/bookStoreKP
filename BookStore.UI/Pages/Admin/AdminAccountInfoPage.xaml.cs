using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.UI.HelperClasses;
using BookStore.UI.Pages.User;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.Admin;

public partial class AdminAccountInfoPage : BasePage
{
    private readonly Account _account;
    
    private AdminAccountInfoViewModel PageViewModel { get; }
    
    public AdminAccountInfoPage(Account account)
    {
        InitializeComponent();

        _account = account;

        DataContext = PageViewModel = new(_account);

        LoadOrders();
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную учётную запись?",
            "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        DataStore.Accounts.DeleteAccount(_account);
        PagesNavigation.AccountsListPage.LoadAccounts();
        
        MessageBox.Show("Вы успешно удалили учётную запись пользователя!", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
        
        NavigationService!.GoBack();
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckDataForValid())
            return;

        var newAccount = new Account
        {
            Login = LoginTb.Text,
            Password = PasswordTb.Text,
            Name = FirstNameTb.Text,
            Surname = LastNameTb.Text,
            Email = EmailTb.Text,
            Phone = PhoneTb.Text,
            IdUser = _account.IdUser
        };

        if (newAccount.Login != _account.Login && DataStore.Users.IsLoginExists(newAccount.Login))
        {
            MessageBox.Show("Данный логин уже используется другим пользователем!", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        if (DataStore.Profiles.IsEmailUsed(newAccount.Email, newAccount.IdUser))
        {
            MessageBox.Show("Данная почта уже используется другим пользователем!", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        if (DataStore.Profiles.IsPhoneUsed(newAccount.Phone, newAccount.IdUser))
        {
            MessageBox.Show("Данный номер телефона уже используется другим пользователем!", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        DataStore.Accounts.UpdateAccount(newAccount);
        PageViewModel.UpdateProperties(newAccount);
        PagesNavigation.AccountsListPage.LoadAccounts();
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginTb.Text = LoginTbl.Text;
        PasswordTb.Text = PasswordTbl.Text;
        EmailTb.Text = EmailTbl.Text;
        PhoneTb.Text = PhoneTbl.Text;
        FirstNameTb.Text = FirstNameTbl.Text;
        LastNameTb.Text = LastNameTbl.Text;

        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void EditBtn_Click(object sender, RoutedEventArgs e)
    {
        SetStatusForTextControls(Visibility.Visible, Visibility.Collapsed);

        EditBtn.Visibility = Visibility.Collapsed;
        CancelBtn.Visibility = Visibility.Visible;
        SaveBtn.Visibility = Visibility.Visible;
    }
    
    private void LoadOrders()
    {
        var orders = DataStore.Orders.GetOrders(_account.IdUser)
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
    
    private void SetStatusForTextControls(Visibility visibilityTb, Visibility visibilityTbl)
    {
        TextBox[] textBoxes = { LoginTb, PasswordTb, EmailTb, PhoneTb, FirstNameTb, LastNameTb };
        foreach (var textBox in textBoxes)
            textBox.Visibility = visibilityTb;

        TextBlock[] textBlocks = { LoginTbl, PasswordTbl, EmailTbl, PhoneTbl, FirstNameTbl, LastNameTbl };
        foreach (var textBlock in textBlocks)
            textBlock.Visibility = visibilityTbl;
    }
    
    private bool IsEmailValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    
    private bool IsPhoneValid(string input) => Regex.IsMatch(input, @"^\+\d{1,3}-\d{2}-\d{3}-\d{2}-\d{2}$");
    
    private bool IsStringValid(string input) => Regex.IsMatch(input, @"^[a-zа-яё-]+$", RegexOptions.IgnoreCase);

    private bool CheckDataForValid()
    {
        if (!IsEmailValid(EmailTb.Text))
        {
            MessageBox.Show("Введена некорректная почта! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (!IsPhoneValid(PhoneTb.Text))
        {
            MessageBox.Show("Введён некорректный номер телефона! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (!IsStringValid(FirstNameTb.Text) || !IsStringValid(LastNameTb.Text))
        {
            MessageBox.Show("Имя/фамилия введены некорректно! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        
        return true;
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
}