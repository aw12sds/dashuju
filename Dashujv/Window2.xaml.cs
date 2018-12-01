using DevExpress.Xpf.Charts;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dashujv
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string strTmp = label3.Content.ToString();
            int txtcount = Encoding.Default.GetBytes(strTmp).Length;
            int loop = txtcount * 7;//大概计算滚动条总长度，和字符多少有关
            int time = loop / 50;//滚动时间控制（滚动速度控制
            Storyboard Mar_Storyboard = new Storyboard();
            label3.RenderTransform = new TranslateTransform();
            Mar_Storyboard.Children.Add(GetWidthAnimation(label3.Name, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(time), 0, loop + grid2.Width));
            Mar_Storyboard.RepeatBehavior = RepeatBehavior.Forever;
            Mar_Storyboard.Begin(this);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(OnTimedEvent);
            timer.Start();

        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            label1.Content = DateTime.Now.ToString();
        }
        private Timeline GetWidthAnimation(string namescope, TimeSpan beginTime, TimeSpan duration, double? fromX, double? toX)
        {
            DependencyProperty[] XpropertyChain = new DependencyProperty[]
            {
                 Rectangle.HeightProperty
            };
            DoubleAnimation yAnimation = new DoubleAnimation()
            {
                From = fromX,
                To = 60,
                Duration = duration,
                BeginTime = beginTime
            };
            Storyboard.SetTargetName(yAnimation, namescope);
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(0)", XpropertyChain));
            return yAnimation;
        }
    }
}
