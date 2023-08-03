using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookStore.Storage.Models;
using BookStore.UI.Pages.User;

namespace BookStore.UI.Pages.Admin;

public partial class AdminBooksListPage : BasePage
{
    private string QuerySearch => SearchTb.Text;
    
    public AdminBooksListPage()
    {
        InitializeComponent();
        
        CategoryCb.SelectionChanged += CategoryCb_OnSelectionChanged;
        FilterCb.SelectionChanged += FilerCb_OnSelectionChanged;

        SearchBtn.Click += (sender, args) =>
        {
            LoadBooks();
        };

        SearchTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                LoadBooks();
        };
        
        LoadBooks();
    }

    public void LoadBooks()
    {
        var selectedCategoryItem = CategoryCb.SelectedItem as ComboBoxItem;
        var selectedCategory = selectedCategoryItem!.Content.ToString();

        if (selectedCategory != "Всё")
        {
            LoadBooks(selectedCategory!);
            return;
        }
        
        var books = DataStore.Books.GetBooks();
        var searchedBooks = books.Where(x => x.Title.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase) 
                                             || x.Author.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase)
                                             || x.Isbn.Replace("-", "")
                                                 .Contains(QuerySearch, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var filteredBooks = FilterBooks(searchedBooks);
        
        SetBooks(filteredBooks);
    }

    private void LoadBooks(string category)
    {
        var books = DataStore.Books.GetBooksByCategory(category);
        var searchedBooks = books.Where(x => x.Title.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase) 
                                             || x.Author.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase)
                                             || x.Isbn.Replace("-", "")
                                                 .Contains(QuerySearch, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var filterBooks = FilterBooks(searchedBooks);
        
        SetBooks(filterBooks);
    }
    
    private Book[] FilterBooks(Book[] books)
    {
        IEnumerable<Book> filteredBooks;
        
        var selectedFilterItem = FilterCb.SelectedItem as ComboBoxItem;
        var selectedFilter = selectedFilterItem!.Content.ToString();
        switch (selectedFilter)
        {
            case "Без сортировки":
                filteredBooks = books;
                break;
            case "Сначала дешёвые":
                filteredBooks = books.OrderBy(x => x.Price);
                break;
            case "Сначала дорогие":
                filteredBooks = books.OrderByDescending(x => x.Price);
                break;
            default:
                throw new Exception("Не найден заданный фильтр");
        }

        return filteredBooks.ToArray();
    }

    private void SetBooks(Book[] books)
    {
        if (books.Length == 0)
        {
            StatusTbl.Text = "Товары с данными параметрами не найдены.";
            StatusTbl.Visibility = Visibility.Visible;
            BooksView.ItemsSource = books;
            return;
        }

        BooksView.ItemsSource = books;
        StatusTbl.Text = string.Empty;
        StatusTbl.Visibility = Visibility.Collapsed;
    }

    private void CategoryCb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LoadBooks();
    }

    private void FilerCb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LoadBooks();
    }

    private void BooksView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var listViewItem = (ListViewItem)sender;
        var book = (Book)listViewItem.Content;

        var productPage = new AdminBookPage(book);
        NavigationService!.Navigate(productPage);
    }
}