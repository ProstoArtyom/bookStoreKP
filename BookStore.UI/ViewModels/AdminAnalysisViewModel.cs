using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.Storage.Repositories;
using BookStore.UI.HelperClasses;

namespace BookStore.UI.ViewModels;

public class AdminAnalysisViewModel : INotifyPropertyChanged
{
    private IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();

    private ObservableCollection<DataItem> _dataChartTotalPrices;
    
    private ObservableCollection<DataItem> _dataChartTotalCounts;
    
    private int _accountsCount;

    private int _booksCount;
    
    private User[] _users;
    
    private Book[] _books;
    
    private CartItem[] _carts;
    
    private Order[] _orders;

    public int AccountsCount
    {
        get => _accountsCount;
        set
        {
            _accountsCount = value;
            OnPropertyChanged(nameof(AccountsCount));
        }
    }
    
    public int BooksCount
    {
        get => _booksCount;
        set
        {
            _booksCount = value;
            OnPropertyChanged(nameof(BooksCount));
        }
    }

    public float AverageBooksCount => BooksCount / (float)AccountsCount;

    public int CartBooksCount => _carts.Sum(x => x.Count);

    public float AverageCartBooksCount => CartBooksCount / (float)AccountsCount;

    public int OrdersCount => _orders.Length;

    public float AverageOrdersCount => OrdersCount / (float)AccountsCount;

    public ObservableCollection<DataItem> DataChartTotalPrices
    {
        get => _dataChartTotalPrices;
        set
        {
            _dataChartTotalPrices = value;
            OnPropertyChanged(nameof(DataChartTotalPrices));
        }
    }
    
    public ObservableCollection<DataItem> DataChartTotalCounts
    {
        get => _dataChartTotalCounts;
        set
        {
            _dataChartTotalCounts = value;
            OnPropertyChanged(nameof(DataChartTotalCounts));
        }
    }
    
    public AdminAnalysisViewModel()
    {
        UpdateProperties();
    }

    public void UpdateProperties()
    {
        var users = DataStore.Users.GetUsers();
        _users = users;
        
        var books = DataStore.Books.GetBooks();
        _books = books;

        var carts = DataStore.Cart.GetCartItems();
        _carts = carts;
        
        var orders = DataStore.Orders.GetOrders();
        _orders = orders;

        AccountsCount = users.Length;
        BooksCount = books.Length;

        var totalPrices = new decimal[12];
        
        foreach (var order in orders)
        {
            var numberOfMonth = order.DateTimeCreated.Month;

            totalPrices[numberOfMonth - 1] += order.Price;
        }

        DataChartTotalPrices = new ObservableCollection<DataItem>
        {
            new() { Label = "Январь", Value = totalPrices[0] },
            new() { Label = "Февраль", Value = totalPrices[1] },
            new() { Label = "Март", Value = totalPrices[2] },
            new() { Label = "Апрель", Value = totalPrices[3] },
            new() { Label = "Май", Value = totalPrices[4] },
            new() { Label = "Июнь", Value = totalPrices[5] },
            new() { Label = "Июль", Value = totalPrices[6] },
            new() { Label = "Август", Value = totalPrices[7] },
            new() { Label = "Сентябрь", Value = totalPrices[8] },
            new() { Label = "Октябрь", Value = totalPrices[9] },
            new() { Label = "Ноябрь", Value = totalPrices[10] },
            new() { Label = "Декабрь", Value = totalPrices[11] },
        };

        var totalCounts = new int[12];
        
        foreach (var order in orders)
        {
            var numberOfMonth = order.DateTimeCreated.Month;

            var count = order.Books.Split(',')
                .Select(x => x.Split('-'))
                .Select(x => int.Parse(x[1]))
                .Sum();
            
            totalCounts[numberOfMonth - 1] += count;
        }
        
        DataChartTotalCounts = new ObservableCollection<DataItem>
        {
            new() { Label = "Январь", Value = totalCounts[0] },
            new() { Label = "Февраль", Value = totalCounts[1] },
            new() { Label = "Март", Value = totalCounts[2] },
            new() { Label = "Апрель", Value = totalCounts[3] },
            new() { Label = "Май", Value = totalCounts[4] },
            new() { Label = "Июнь", Value = totalCounts[5] },
            new() { Label = "Июль", Value = totalCounts[6] },
            new() { Label = "Август", Value = totalCounts[7] },
            new() { Label = "Сентябрь", Value = totalCounts[8] },
            new() { Label = "Октябрь", Value = totalCounts[9] },
            new() { Label = "Ноябрь", Value = totalCounts[10] },
            new() { Label = "Декабрь", Value = totalCounts[11] },
        };
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public class DataItem
    {
        public string Label { get; set; }
        public decimal Value { get; set; }
    }
}