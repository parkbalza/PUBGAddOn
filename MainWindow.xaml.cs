using DesktopWPFAppLowLevelKeyboardHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private LowLevelKeyboardListener _listener;
        private Boolean _mapOn = false;
        DispatcherTimer _timer;
        TimeSpan _time;
        private Boolean _timerOn = false;
        private int _circleseq = 0;
        private int _circlesub = -1;
        private int precircle = 120;
        private int[,] circle = new int[9, 2] { { 300,300},{200,140 },{150,90 },{120,60 },{120,30 },{90,30 },{90,30 },{60,30 },{195,15 } };
        Point spt, ept;
        private Boolean predraw = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            timerTxt.Foreground = Brushes.LimeGreen;
            CircleSeq.Foreground = Brushes.LimeGreen;

            _listener.HookKeyboard();
            mainMap.Visibility = Visibility.Hidden;

            _time = TimeSpan.FromSeconds(precircle);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timerTxt.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero || _timerOn == false)
                {
                    _timer.Stop();
                }
                if(_time == TimeSpan.Zero && _circleseq < 9)
                {
                    if (_circlesub==-1)
                    {
                        _circlesub = 0;
                    }
                    else if (_circlesub == 0)
                    {
                        _circlesub = 1;
                    }
                    else
                    {
                        _circlesub = 0;
                        _circleseq++;
                    }
                    _time = TimeSpan.FromSeconds(circle[_circleseq, _circlesub]);
                    CircleSeq.Text = _circleseq + "_" + _circlesub;
                    _timer.Start();
                }
                else if (_time == TimeSpan.Zero && _circleseq >= 9)
                {
                    _timer.Stop();
                    _circlesub = -1;
                    _circleseq = 0;
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            timerTxt.Visibility = Visibility.Hidden;
            cnv.Opacity = 0;
        }
        
        private void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            //this.textBox_DisplayKeyboardInput.Text += e.KeyPressed.ToString();
            if(e.KeyPressed == Key.F1 && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                _mapOn = false;
                _timerOn = false;
                _time = TimeSpan.FromSeconds(precircle);
                CircleSeq.Text = "Pre Circle";
                _circlesub = -1;
                _circleseq = 0;
            }
            if (e.KeyPressed == Key.L)
            {
                _mapOn = !_mapOn;
            }
            if (e.KeyPressed == Key.Return && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                _timerOn = true;
                _timer.Start();
            }
            if (e.KeyPressed == Key.Space && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (predraw)
                {
                    System.Diagnostics.Debug.WriteLine("pre draw");
                    cnv.Opacity = 0.1;
                    predraw = false;
                    plane.Children.Clear();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("end draw");
                    cnv.Opacity = 0;
                    predraw = true;
                }
            }
            if (_mapOn)
            {
                mainMap.Visibility = Visibility.Visible;
                plane.Visibility = Visibility.Visible;
                plane.IsHitTestVisible = false;
            }
            else
            {
                mainMap.Visibility = Visibility.Hidden;
                plane.Visibility = Visibility.Hidden;
            }
            if (_timerOn)
            {   
                timerTxt.Visibility = Visibility.Visible;
            }
            else
            {
                timerTxt.Visibility = Visibility.Hidden;
            }
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void cnv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)

        {

            spt = e.GetPosition(cnv);

        }

        private void cnv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)

        {

            //ept = e.GetPosition(cnv);

            //DrawLine(spt, ept);

        }



        private void cnv_MouseMove(object sender, MouseEventArgs e)

        {

            if (e.LeftButton == MouseButtonState.Pressed)

            {

                ept = e.GetPosition(cnv);

            }

            DrawLine(spt, ept);
        }

        void DrawLine(Point spt, Point ept)

        {

            Line link1 = new Line();
            Line link2 = new Line();
            Line link3 = new Line();

            link1.X1 = spt.X;

            link1.Y1 = spt.Y;

            link1.X2 = ept.X;

            link1.Y2 = ept.Y;

            link2.X1 = spt.X;

            link2.Y1 = spt.Y;

            link2.X2 = ept.X;

            link2.Y2 = ept.Y;

            link3.X1 = spt.X;

            link3.Y1 = spt.Y;

            link3.X2 = ept.X;

            link3.Y2 = ept.Y;

            link1.Stroke = Brushes.White;
            link2.Stroke = Brushes.CadetBlue;
            link3.Stroke = Brushes.OrangeRed;

            link1.StrokeThickness = 5;
            link2.StrokeThickness = 330;
            link3.StrokeThickness = 520;

            link1.Opacity = 0.1;
            link2.Opacity = 0.1;
            link3.Opacity = 0.1;

            //if (cnv.Children.Contains(link) == true)

            //{

            plane.Children.Clear();

            //}

            //plane.Children.Add(link3);
            //plane.Children.Add(link2);
            plane.Children.Add(link1);
            //cnv.Opacity = 0;
        }
    }
}
