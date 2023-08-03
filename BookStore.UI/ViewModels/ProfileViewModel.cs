using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BookStore.Storage.Models;
using BookStore.Storage.Repositories;

namespace BookStore.UI.ViewModels;

public class ProfileViewModel : INotifyPropertyChanged
{
    private IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();

    private ObservableCollection<DataItem> dataChartTotalPrices;
    
    private ObservableCollection<DataItem> dataChartTotalCounts;
    
    private readonly Profile _profile;

    private string _name;
    
    private string _surname;
    
    private string _email;

    private string _phone;

    private string _address;
    
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }    
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }    
    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    public ObservableCollection<DataItem> DataChartTotalPrices
    {
        get => dataChartTotalPrices;
        set
        {
            dataChartTotalPrices = value;
            OnPropertyChanged(nameof(DataChartTotalPrices));
        }
    }
    
    public ObservableCollection<DataItem> DataChartTotalCounts
    {
        get => dataChartTotalCounts;
        set
        {
            dataChartTotalCounts = value;
            OnPropertyChanged(nameof(DataChartTotalCounts));
        }
    }

    public ProfileViewModel(Profile profile)
    {
        _profile = profile;

        Name = profile.Name;
        Surname = profile.Surname;
        Email = profile.Email;
        Phone = profile.Phone;
        
        UpdateAnalysis();
    }
    
    public void UpdateAnalysis()
    {
        var orders = DataStore.Orders.GetOrders(AppUser.Instance.AccountId);
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

    public void UpdateProperties(Profile newProfile)
    {
        Name = newProfile.Name;
        Surname = newProfile.Surname;
        Email = newProfile.Email;
        Phone = newProfile.Phone;
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