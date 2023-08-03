using System.Windows.Controls;
using BookStore.UI.ViewModels;

namespace BookStore.UI.Pages.Admin;

public partial class AdminAnalysisPage : BasePage
{
    private AdminAnalysisViewModel PageViewModel { get; }
    
    public AdminAnalysisPage()
    {
        InitializeComponent();

        DataContext = PageViewModel = new AdminAnalysisViewModel();
    }
}