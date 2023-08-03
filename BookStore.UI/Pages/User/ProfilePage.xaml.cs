using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using BookStore.Storage.Models;
using BookStore.UI.HelperClasses;
using BookStore.UI.ViewModels;
using SQLitePCL;

namespace BookStore.UI.Pages.User;

public partial class ProfilePage : BasePage
{
    private delegate bool StringValidHandler(string input);
    
    private readonly Profile _profile;
    
    private ProfileViewModel PageViewModel { get; }
    
    public ProfilePage()
    {
        InitializeComponent();

        var profile = DataStore.Profiles.GetProfileByID(AppUser.Instance.AccountId);
        _profile = profile;
        
        DataContext = PageViewModel = new ProfileViewModel(profile);
    }

    private void EditBtn_Click(object sender, RoutedEventArgs e)
    {
        SetStatusForTextControls(Visibility.Visible, Visibility.Collapsed);

        EditBtn.Visibility = Visibility.Collapsed;
        CancelBtn.Visibility = Visibility.Visible;
        SaveBtn.Visibility = Visibility.Visible;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        NameTb.Text = NameTbl.Text;
        SurnameTb.Text = SurnameTbl.Text;
        EmailTb.Text = EmailTbl.Text;
        PhoneTb.Text = PhoneTbl.Text;
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckDataForValid())
            return;

        var newProfile = new Profile
        {   
            Id = _profile.Id,
            Name = NameTb.Text,
            Surname = SurnameTb.Text,
            Email = EmailTb.Text,
            Phone = PhoneTb.Text
        };

        if (DataStore.Profiles.IsEmailUsed(newProfile.Email, AppUser.Instance.AccountId))
        {
            MessageBox.Show("Данная почта уже используется другим пользователем!", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        if (DataStore.Profiles.IsPhoneUsed(newProfile.Phone, AppUser.Instance.AccountId))
        {
            MessageBox.Show("Данный номер телефона уже используется другим пользователем!", 
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        DataStore.Profiles.SetProfile(newProfile);
        PageViewModel.UpdateProperties(newProfile);
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SetStatusForTextControls(Visibility visibilityTb, Visibility visibilityTbl)
    {
        TextBox[] textBoxes = { NameTb, SurnameTb, EmailTb, PhoneTb };
        foreach (var textBox in textBoxes)
            textBox.Visibility = visibilityTb;

        TextBlock[] textBlocks = { NameTbl, SurnameTbl, EmailTbl, PhoneTbl };
        foreach (var textBlock in textBlocks)
            textBlock.Visibility = visibilityTbl;
    }
    
    private void ExitBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите выйти из учётной записи?", 
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        WindowsNavigation.MainWindow.Hide();
        WindowsNavigation.AuthWindow.Show();
    }
    
    private bool IsEmailValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    
    private bool IsPhoneValid(string input) => Regex.IsMatch(input, @"^\+\d{1,3}-\d{2}-\d{3}-\d{2}-\d{2}$");
    
    private bool IsStringValid(string input) => Regex.IsMatch(input, @"^[a-zа-яё-]+$", RegexOptions.IgnoreCase);

    private bool CheckDataForValid()
    {
        StringValidHandler IsStringValidHandler = IsEmailValid;
        
        if (!IsStringValidHandler(EmailTb.Text))
        {
            MessageBox.Show("Введена некорректная почта! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        IsStringValidHandler = IsPhoneValid;
        
        if (!IsStringValidHandler(PhoneTb.Text))
        {
            MessageBox.Show("Введён некорректный номер телефона! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        IsStringValidHandler = IsStringValid;
        
        if (!IsStringValidHandler(NameTb.Text) || !IsStringValidHandler(SurnameTb.Text))
        {
            MessageBox.Show("Имя/фамилия введены некорректно! Повторите попытку.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        
        return true;
    }

    public void LoadAnalysis()
    {
        PageViewModel.UpdateAnalysis();
    }
}