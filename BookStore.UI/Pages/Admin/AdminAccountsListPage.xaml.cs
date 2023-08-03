using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.Admin;

public partial class AdminAccountsListPage : BasePage
{
    private AdminAccountsViewModel PageViewModel { get; set; }
    
    public AdminAccountsListPage()
    {
        InitializeComponent();

        DataContext = PageViewModel = new();
    }

    private void AccountsGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedAccount = AccountsDataGrid.SelectedItem as Account;
        if (selectedAccount == null)
            return;

        var accountInfoPage = new AdminAccountInfoPage(selectedAccount);
        NavigationService!.Navigate(accountInfoPage);
    }

    public void LoadAccounts()
    {
        PageViewModel.LoadAccounts();
    }
}