using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BookStore.Storage.Models;
using BookStore.UI.HelperClasses;

namespace BookStore.UI.Pages.Admin;

public partial class AdminAddBookPage : BasePage
{
    private string selectedImagePath;

    public AdminAddBookPage()
    {
        InitializeComponent();
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

            BookImage.Source = bitmap;
        }
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        string title, author, category, isbn, description;
        int count;
        decimal price;
        byte[] image;
        
        try
        {
            title = NameTb.Text.Trim();
            author = AuthorTb.Text.Trim();
            description = DescriptionTb.Text.Trim();
            isbn = IsbnTb.Text.Trim();

            if (title == string.Empty 
                || description == string.Empty
                || author == string.Empty
                || isbn == string.Empty)
                throw new Exception();
            
            count = int.Parse(CountTb.Text.Trim());
            price = Convert.ToDecimal(PriceTb.Text.Trim(), CultureInfo.InvariantCulture);

            if (count < 0 || price < 0)
                throw new Exception();

            if (BookImage.Source == null)
                throw new Exception();

            using (var stream = new MemoryStream())
            {
                var bmp = BookImage.Source as BitmapImage;
                
                var jpegEncoder = new JpegBitmapEncoder();
                jpegEncoder.Frames.Add(BitmapFrame.Create(bmp));
                jpegEncoder.Save(stream);

                image = stream.ToArray();
            }
            
            var selectedCategoryItem = CategoryTb.SelectedItem as ComboBoxItem;
            category = selectedCategoryItem!.Content.ToString()!;
        }
        catch
        {
            MessageBox.Show("Неккоректные данные! Попробуйте ещё раз.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var book = new Book
        {
            Title = title,
            Author = author,
            Category = category,
            Isbn = isbn,
            Count = count,
            Price = price,
            Description = description,
            Image = image
        };

        DataStore.Books.AddBook(book);
        
        MessageBox.Show("Вы успешно добавили книгу в список.", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
        
        NameTb.Clear();
        AuthorTb.Clear();
        DescriptionTb.Clear();
        IsbnTb.Clear();
        CountTb.Clear();
        PriceTb.Clear();
        BookImage.Source = null;
        CategoryTb.SelectedIndex = 0;
        
        PagesNavigation.AdminBooksListPage.LoadBooks();
        NavigationService!.GoBack();
    }
}