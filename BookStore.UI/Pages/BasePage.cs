using System.Windows.Controls;
using BookStore.Storage.Repositories;

namespace BookStore.UI.Pages;

public class BasePage : Page
{
    protected IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();

}