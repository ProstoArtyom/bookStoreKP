using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BookStore.Storage.Models;
using BookStore.UI.HelperClasses;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.Admin;

public partial class AdminBookPage : BasePage
{
    private readonly Book _book;
    
    private string selectedImagePath;

    private BookPageViewModel PageViewModel { get; }
    
    public AdminBookPage(Book book)
    {
        InitializeComponent();

        _book = book;
        
        DataContext = PageViewModel = new BookPageViewModel(_book);

        KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Escape)
                NavigationService!.GoBack();
        };
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
    
    private void EditBtn_Click(object sender, RoutedEventArgs e)
    {
        SetStatusForTextControls(Visibility.Visible, Visibility.Collapsed);

        SelectPhotoBtn.Visibility = Visibility.Visible;
        BookImage.Visibility = Visibility.Collapsed;
        
        EditBtn.Visibility = Visibility.Collapsed;
        CancelBtn.Visibility = Visibility.Visible;
        SaveBtn.Visibility = Visibility.Visible;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        TitleTb.Text = TitleTbl.Text;
        AuthorTb.Text = AuthorTbl.Text;
        CategoryTb.Text = CategoryTbl.Text;
        IsbnTb.Text = IsbnTbl.Text;
        PriceTb.Text = PriceTbl.Text;
        CountTb.Text = CountTbl.Text;
        DescriptionTb.Text = DescriptionTbl.Text;
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        SelectPhotoBtn.Visibility = Visibility.Collapsed;
        BookImage.Visibility = Visibility.Visible;
        
        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        decimal price;
        int count;
        byte[] image;
        try
        {
            price = Convert.ToDecimal(PriceTb.Text, CultureInfo.InvariantCulture);
            count = Convert.ToInt32(CountTb.Text, CultureInfo.InvariantCulture);
            
            using (var stream = new MemoryStream())
            {
                var bmp = PreviewImage.Source as BitmapImage;
                
                var jpegEncoder = new JpegBitmapEncoder();
                jpegEncoder.Frames.Add(BitmapFrame.Create(bmp));
                jpegEncoder.Save(stream);

                image = stream.ToArray();
            }
        }
        catch
        {
            MessageBox.Show("Некорректные данные!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        var newBook = new Book
        {   
            Id = _book.Id,
            Title = TitleTb.Text,
            Author = AuthorTb.Text,
            Category = CategoryTb.Text,
            Isbn = IsbnTb.Text,
            Price = price,
            Count = count,
            Description = DescriptionTb.Text,
            Image = image
        };

        DataStore.Books.UpdateBook(newBook);
        PageViewModel.UpdateProperties(newBook);
        PagesNavigation.AdminBooksListPage.LoadBooks();
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        SelectPhotoBtn.Visibility = Visibility.Collapsed;
        BookImage.Visibility = Visibility.Visible;
        
        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SetStatusForTextControls(Visibility visibilityTb, Visibility visibilityTbl)
    {
        TextBox[] textBoxes = { TitleTb, AuthorTb, CategoryTb, IsbnTb, PriceTb, CountTb, DescriptionTb };
        foreach (var textBox in textBoxes)
            textBox.Visibility = visibilityTb;

        TextBlock[] textBlocks = { TitleTbl, AuthorTbl, CategoryTbl, IsbnTbl, PriceTbl, CountTbl, DescriptionTbl };
        foreach (var textBlock in textBlocks)
            textBlock.Visibility = visibilityTbl;
    }
    
    private void SelectPhotoBtn_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            selectedImagePath = openFileDialog.FileName;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedImagePath);
            bitmap.EndInit();

            PreviewImage.Source = bitmap;
        }
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить данную книгу?", 
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        DataStore.Books.DeleteBookById(_book.Id);
        
        MessageBox.Show("Вы успешно удалили книгу из списка.", 
            "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        
        PagesNavigation.AdminBooksListPage.LoadBooks();
        NavigationService!.GoBack();
    }
}