namespace BookStore.UI.HelperClasses;

public class LastSession
{
    public static string Login
    {
        get => Properties.Settings.Default.Login;

        set
        {
            Properties.Settings.Default["Login"] = value;
            Properties.Settings.Default.Save();
        }
    }

    public static string Password
    {
        get => Properties.Settings.Default.Password;

        set
        {
            Properties.Settings.Default["Password"] = value;
            Properties.Settings.Default.Save();
        }
    }

    public static int AccountId
    {
        get => Properties.Settings.Default.AccountId;

        set
        {
            Properties.Settings.Default["AccountId"] = value;
            Properties.Settings.Default.Save();
        }
    }
}