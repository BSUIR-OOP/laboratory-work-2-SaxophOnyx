using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        //Not MVVM!
        public void MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            double x = e.MouseDevice.GetPosition(sender as Image).X;
            double y = e.MouseDevice.GetPosition(sender as Image).Y;

            (DataContext as ViewModel).AddMarkupPoint(x, y);
        }
    }
}
