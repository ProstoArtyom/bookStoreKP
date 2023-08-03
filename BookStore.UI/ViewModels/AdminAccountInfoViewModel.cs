using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookStore.Storage.Models;

namespace BookStore.UI.ViewModels;

public class AdminAccountInfoViewModel : INotifyPropertyChanged
{
    private Account _account;
    
    private int _id;

    private string _login;

    private string _password;

    private string _email;
    
    private string _phone;

    private string _name;

    private string _surname;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public string Login
    {
        get  => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }
    
    public string Password
    {
        get  => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    
    public string Email
    {
        get  => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    
    public string Phone
    {
        get  => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }
    
    public string Name
    {
        get  => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    public string Surname
    {
        get  => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }
    
    public AdminAccountInfoViewModel(Account account)
    {
        _account = account;

        UpdateProperties();
    }

    public void UpdateProperties()
    {
        Id = _account.IdUser;
        Login = _account.Login;
        Password = _account.Password;
        Email = _account.Email;
        Phone = _account.Phone;
        Name = _account.Name;
        Surname = _account.Surname;
    }
    
    public void UpdateProperties(Account account)
    {
        _account = account;

        UpdateProperties();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}