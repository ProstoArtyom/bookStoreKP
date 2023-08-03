using BookStore.UI.HelperClasses;

namespace BookStore.UI;

public class AppUser
{
    public static AppUser Instance { get; private set; } = new AppUser();
    
    public string Login { get; }

    public string Password { get; }

    public int AccountId { get; }

    private AppUser() { }

    private AppUser(string login, string password, int accountId)
    {
        Login = login;
        Password = password;
        AccountId = accountId;
    }

    public static void SetInstance(string login, string password, int accountId)
    {
        SetLastSessionUser(login, password, accountId);
        Instance = new AppUser(login, password, accountId);
    }

    private static void SetLastSessionUser(string login, string password, int accountId)
    {
        LastSession.Login = login;
        LastSession.Password = password;
        LastSession.AccountId = accountId;
    }
}