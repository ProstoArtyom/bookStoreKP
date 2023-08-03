using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using BookStore.Storage.Models;

namespace BookStore.UI.ViewModels;

public class CartPageViewModel : INotifyPropertyChanged
{
    private decimal totalPrice;

    private CartItem[] cartProducts;

    public CartItem[] CartProducts
    {
        get => cartProducts;
        set
        {
            cartProducts = value;
            TotalPrice = CartProducts.Select(x => x.Price * x.Count).Sum();
            OnPropertyChanged(nameof(CartProducts));
        }
    }

    public decimal TotalPrice
    {
        get => totalPrice;
        private set
        {
            totalPrice = value;
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}