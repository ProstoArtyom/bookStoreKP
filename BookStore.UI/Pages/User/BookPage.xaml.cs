using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.UI.HelperClasses;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.User;

public partial class BookPage : BasePage
{
    private readonly Book _book;
    
    private BookPageViewModel PageViewModel { get; }
    
    public BookPage(Book book)
    {
        InitializeComponent();

        _book = book;
        
        DataContext = PageViewModel = new BookPageViewModel(_book);

        if (_book.Count <= 0)
        {
            AddToCartGrid.Visibility = Visibility.Collapsed;
            StatusTbl.Visibility = Visibility.Visible;
        }
        
        KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Escape)
                NavigationService!.GoBack();
        };
    }

    private void AddToCartButton_Click(object sender, RoutedEventArgs e)
    {
        var numericTextBox = numericTextBoxControl.numericTextBox;
        if (!int.TryParse(numericTextBox.Text, out int count))
        {
            MessageBox.Show("Введенное значение количества товара неккоректно!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (count > _book.Count || count <= 0)
        {
            MessageBox.Show("Введённое количество товара недоступно!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        var cartItem = new CartItem
        {
            IdBook = _book.Id,
            IdUser = AppUser.Instance.AccountId,
            Count = count,
            DateTimeAdded = DateTime.Now
        };
            
        DataStore.Cart.AddCartItemToCart(cartItem);
        PagesNavigation.CartPage.LoadCartProducts();
        MessageBox.Show("Товар успешно добавлен в корзину", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
}