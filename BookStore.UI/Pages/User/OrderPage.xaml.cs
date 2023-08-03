using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using BookStore.Storage.Models;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.User;

public partial class OrderPage : BasePage
{
    private readonly Order _order;

    public OrderPageViewModel PageViewModel { get; }

    public OrderPage(Order order)
    {
        InitializeComponent();

        DataContext = PageViewModel = new OrderPageViewModel(order);

        _order = order;

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

    private void ProductsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedProduct = BooksGridView.SelectedItem as Book;
        if (selectedProduct == null)
            return;

        var book = DataStore.Books.GetBookByID(selectedProduct.Id);
        var bookPage = new BookPage(book);
        NavigationService!.Navigate(bookPage);
    }

    private void PrintBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            this.IsEnabled = false;
            var printDialog = new PrintDialog();
            printDialog.ShowDialog();
            printDialog.PrintTicket.PageScalingFactor = 100;
            printDialog.PrintVisual(this, "Order");
        }
        catch (Exception exception)
        {
            MessageBox.Show("Произошла неопознанная ошибка!", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
            Debug.Print(exception.Message);
        }
        finally
        {
            this.IsEnabled = true;
        }
    }

    private void ExportBtn_Click(object sender, RoutedEventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var child in OrderInfoPanel.Children)
        {
            if (child is StackPanel stackPanel)
            {
                foreach (var textBlock in stackPanel.Children.OfType<TextBlock>())
                    sb.AppendLine(textBlock.Text);
            }
        }

        sb.AppendLine();

        if (BooksGridView.Columns.Count > 0)
        {
            foreach (var column in BooksGridView.Columns)
            {
                if (column is DataGridTextColumn textColumn)
                {
                    string header = textColumn.Header?.ToString();
                    if (!string.IsNullOrEmpty(header))
                        sb.Append(header).Append("\t");
                }
            }

            sb.AppendLine();

            foreach (var item in BooksGridView.Items)
            {
                foreach (var column in BooksGridView.Columns)
                {
                    if (column is DataGridTextColumn textColumn)
                    {
                        var cellValue = textColumn.GetCellContent(item) as TextBlock;
                        string cellText = cellValue?.Text ?? string.Empty;
                        sb.Append(cellText).Append("\t");
                    }
                }

                sb.AppendLine();
            }
        }

        try
        {
            using FileStream fs = new FileStream("orderInfo.txt", FileMode.Create);
            using StreamWriter writer = new StreamWriter(fs);
            writer.Write(sb.ToString());
        }
        catch 
        {
            MessageBox.Show("Произошла неопознанная ошибка!", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        MessageBox.Show("Данные были успешно экспортированы.", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
}