using System.Windows.Input;
using BookStore.UI.HelperClasses.Commands;

namespace BookStore.UI.ViewModels;

public class UserAuthViewModel
{
    public ICommand About { get; } = new AboutCommand();
}