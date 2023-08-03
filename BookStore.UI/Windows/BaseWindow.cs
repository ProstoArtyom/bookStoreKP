using System.ComponentModel;
using System.Windows;
using BookStore.Storage.Repositories;

namespace BookStore.UI.Windows;

public class BaseWindow : Window
{
    protected IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();
    
    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        Application.Current.Shutdown();
    }
}