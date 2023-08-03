using System;
using System.Windows;
using System.Windows.Input;

namespace BookStore.UI.HelperClasses.Commands;

public class AboutCommand : ICommand
{
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        MessageBox.Show("Автор: Шашок Артём Сергеевич\n" 
                        + "Группа: 54ТП\n"
                        + "УО \"МГК цифровых технологий\"\n\n"
                        + "При возникновении вопросов - напишите нам\n"
                        + "на электронную почту: BelKnigaApp@mail.ru", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public event EventHandler? CanExecuteChanged;
}