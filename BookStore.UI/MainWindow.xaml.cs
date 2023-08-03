using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStore.UI.HelperClasses;
using BookStore.UI.Windows;

namespace BookStore.UI
{
    public partial class MainWindow : BaseWindow
    {
        private AuthWindow AuthWindow { get; }
        
        public MainWindow()
        {
            InitializeComponent();

            WindowsNavigation.MainWindow = this;
            AuthWindow = WindowsNavigation.AuthWindow = new AuthWindow();
            
            Hide();
            var splashWindow = new Splash();
            splashWindow.Show();
        }
    }
}