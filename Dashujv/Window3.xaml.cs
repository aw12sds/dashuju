using NetWork.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Topmost = true;
            this.Left = 0.0;
            this.Top = 0.0;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            getData.getiprouter();
            string strSql = "select 项目名称,项目描述,上传人,上传时间,联系电话 from tb_xiangmugongxiang where 确认 is null";
            DataTable dt = null;
           

                dt = SQLhelp.GetDataTablexiangmuguanli(strSql, CommandType.Text);
                string show = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string 项目名称 = dt.Rows[i]["项目名称"].ToString();
                    string 项目描述 = dt.Rows[i]["项目描述"].ToString();
                    string 上传人 = dt.Rows[i]["上传人"].ToString();
                    string 上传时间 = dt.Rows[i]["上传时间"].ToString();
                    string 联系电话 = dt.Rows[i]["联系电话"].ToString();
                    show = show + (i + 1) + ".项目名称:" + 项目名称 + ",  项目描述:" + 项目描述 + ",  上传人:" + 上传人 + ",  上传时间:" + 上传时间 + ",  联系电话:" + 联系电话 + "\r\n\r\n";
                }
                textBlock.Text = show;
                textBlock.Visibility = Visibility.Hidden;

                Thread thread1 = new Thread(new ThreadStart(Thread1));
                thread1.Start();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += new EventHandler(OnTimedEvent);
                timer.Start();

          

              

           
            
          
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {

    try

    {
                string strSql = "select 项目名称,项目描述,上传人,上传时间,联系电话 from tb_xiangmugongxiang where 确认 is null";
                DataTable dt = SQLhelp.GetDataTablexiangmuguanli(strSql, CommandType.Text);
                string show = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string 项目名称 = dt.Rows[i]["项目名称"].ToString();
                    string 项目描述 = dt.Rows[i]["项目描述"].ToString();
                    string 上传人 = dt.Rows[i]["上传人"].ToString();
                    string 上传时间 = dt.Rows[i]["上传时间"].ToString();
                    string 联系电话 = dt.Rows[i]["联系电话"].ToString();
                    show = show + (i + 1) + ".项目名称:" + 项目名称 + ",  项目描述:" + 项目描述 + ",  上传人:" + 上传人 + ",  上传时间:" + 上传时间 + ",  联系电话:" + 联系电话 + "\r\n\r\n";
                }
                textBlock.Text = show;

            }

        catch (Exception ex)

        {
            }

            finally

            {

                //不管什么情况都会执行，包括try catch 里面用了return ,可以理解为只要执行了try或者catch，就一定会执行 finally  

            }
          
        }
        public void Thread1()
        {
            Thread.Sleep(1000);
            double h1 = textBlock.ActualHeight;
            Action action1 = () =>
            {
                textBlock.Visibility = Visibility.Visible;
                textBlock.RenderTransform = new TranslateTransform();
                Storyboard Mar_Storyboard = new Storyboard();

                //Mar_Storyboard.Children.Add(GetWidthAnimation(label1.Name, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(time), 40, loop + grid2.Height));
                Mar_Storyboard.Children.Add(GetWidthAnimation(textBlock.Name, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(h1/3), 10, h1));

                Mar_Storyboard.RepeatBehavior = RepeatBehavior.Forever;
                Mar_Storyboard.Begin(this);
            };
            textBlock.Dispatcher.BeginInvoke(action1);

           
            //string strTmp = textBlock.Text.ToString();
            //int txtcount = Encoding.Default.GetBytes(strTmp).Length;
            //int loop = txtcount * 7;//大概计算滚动条总长度，和字符多少有关
            //int time = loop / 100;//滚动时间控制（滚动速度控制
           
        }
        private Timeline GetWidthAnimation(string namescope, TimeSpan beginTime, TimeSpan duration, double? fromX, double? toX)
        {
            DependencyProperty[] XpropertyChain = new DependencyProperty[]
            {
                 Rectangle.HeightProperty
            };
            DoubleAnimation yAnimation = new DoubleAnimation()
            {
                From = 0,
                To = toX+250,
                Duration = duration,
                BeginTime = beginTime
            };
            Storyboard.SetTargetName(yAnimation, namescope);
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(0)", XpropertyChain));
            return yAnimation;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double h = textBlock.ActualHeight;
            int i = 0;
        }
    }
}
