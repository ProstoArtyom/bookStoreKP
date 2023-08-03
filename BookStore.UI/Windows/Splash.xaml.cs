using System;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using BookStore.UI.HelperClasses;
using Timer = System.Timers.Timer;

namespace BookStore.UI.Windows;

public partial class Splash : BaseWindow
{
    public Splash()
    {
        InitializeComponent();

        var worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += Worker_DoWork;
        worker.RunWorkerCompleted += (s, a) =>
        {
            Hide(); 
            WindowsNavigation.AuthWindow.Show();
        };

        worker.ProgressChanged += (s, progressChangedArgs) => 
            myProgressBar.Value = progressChangedArgs.ProgressPercentage;
        
        worker.RunWorkerAsync();
    }

    private static void Worker_DoWork(object? sender, DoWorkEventArgs e)
    {
        var rand = new Random();
        
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(rand.Next(20, 40));
            ((BackgroundWorker)sender).ReportProgress(i);
        }
    }
    
    private void Window_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
}