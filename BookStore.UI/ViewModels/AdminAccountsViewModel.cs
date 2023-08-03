using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.Storage.Repositories;
using BookStore.UI.HelperClasses;

namespace BookStore.UI.ViewModels;

public class AdminAccountsViewModel : INotifyPropertyChanged
{
    private IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();

    private Account[] _accounts;

    public AdminAccountsViewModel()
    {
        LoadAccounts();
    }
    
    public Account[] Accounts
    {
        get => _accounts;
        set
        {
            _accounts = value;
            OnPropertyChanged(nameof(Accounts));
        }
    }

    public void LoadAccounts()
    {
        var accounts = DataStore.Accounts.GetAccounts();

        Accounts = accounts;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}