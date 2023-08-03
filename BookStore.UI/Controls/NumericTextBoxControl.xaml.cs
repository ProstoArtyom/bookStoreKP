using System.Windows;
using System.Windows.Controls;

namespace BookStore.UI.Controls;

public partial class NumericTextBoxControl : UserControl
{
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(NumericTextBoxControl), new PropertyMetadata(1));
    
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set
        {
            if (value >= 1)
                SetValue(ValueProperty, value);
        }
    }

    public NumericTextBoxControl()
    {
        InitializeComponent();

        numericTextBox.PreviewTextInput += (sender, e) =>
        {
            var textBox = (TextBox)sender; 
            
            if (!char.IsDigit(e.Text, e.Text.Length - 1)
            || (textBox.Text.Length == 0 && e.Text == "0"))
                e.Handled = true;
        };

        numericTextBox.TextChanged += (sender, args) =>
        {
            var textBox = (TextBox)sender; 
            
            if (textBox.Text.Length > 0 && textBox.Text[0] == '0')
            {
                textBox.Text = textBox.Text.Remove(0, 1);
                textBox.CaretIndex = 1;
            }
        };
    }

    private void IncreaseButton_Click(object sender, RoutedEventArgs e)
    {
        Value++;
    }

    private void DecreaseButton_Click(object sender, RoutedEventArgs e)
    {
        Value--;
    }
}