using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BookStore.Storage;

namespace BookStore.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void AppStartup(object sender, StartupEventArgs e)
        {
            var _contentRootPath = AppDomain.CurrentDomain.BaseDirectory;
            var dbConnectionString = BookStore.UI.Properties.Settings.Default["ConnectionString"].ToString();
            StorageParameters.ConnectionString = dbConnectionString;
        }
    }
}