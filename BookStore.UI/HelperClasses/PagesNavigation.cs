using BookStore.UI.Pages.Admin;
using BookStore.UI.Pages.User;

namespace BookStore.UI.HelperClasses;

public static class PagesNavigation
{
    // User Pages
    public static UserMainPage UserMainPage => new();

    public static BooksListPage BooksListPage { get; set; }
    
    public static CartPage CartPage { get; set; }
    
    public static ProfilePage ProfilePage { get; set; }
    
    public static OrdersListPage OrdersPage { get; set; }
    
    // Admin Pages
    public static AdminMainPage AdminMainPage => new();
    
    public static AdminBooksListPage AdminBooksListPage { get; set; }
    
    public static AdminAccountsListPage AccountsListPage { get; set; }
    
    public static AdminOrdersListPage AdminOrdersListPage { get; set; }
    
    public static AdminAnalysisPage AdminAnalysisPage { get; set; }
}