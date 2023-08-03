using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookStore.Storage.Models;

namespace BookStore.UI.ViewModels;

public class BookPageViewModel : INotifyPropertyChanged
{
    private Book _book;

    public Book Book
    {
        get => _book;
        set
        {
            _book = value;
            OnPropertyChanged(nameof(Book));
            
            UpdateProperties();
        }
    }

    private string _title;
    
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    private string _category;
    
    public string Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged(nameof(Category));
        }
    }
    
    private string _author;
    
    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged(nameof(Author));
        }
    }
    
    private decimal _price;
    
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }
    
    private string _isbn;
    
    public string Isbn
    {
        get => _isbn;
        set
        {
            _isbn = value;
            OnPropertyChanged(nameof(Isbn));
        }
    }
    
    private string _description;
    
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }
    
    private int _count;
    
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            OnPropertyChanged(nameof(Count));
        }
    }

    private byte[] _image;

    public byte[] Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged(nameof(Image));
        }
    }

    public BookPageViewModel(Book book)
    {
        _book = book;
        
        UpdateProperties();
    }
    
    public void UpdateProperties(Book newBook)
    {
        Book = newBook;
    }

    private void UpdateProperties()
    {
        Title = Book.Title;
        Category = Book.Category;
        Author = Book.Author;
        Price = Book.Price;
        Isbn = Book.Isbn;
        Description = Book.Description;
        Count = Book.Count;
        Image = Book.Image;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}