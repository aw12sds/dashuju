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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dashujv
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(OnTimedEvent);
            timer.Start();
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            Random num = new Random();
            this.chart3.Value = num.Next(1, 10);
            this.chart4.Value = 3;
            this.chart5.Value = 5;
            label1.Content= num.Next(300, 1000);
            label4.Content = num.Next(300, 1000);
        }
    }
}
