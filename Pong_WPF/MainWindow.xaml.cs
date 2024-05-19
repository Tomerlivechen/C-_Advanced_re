using System.Text;
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

namespace Pong_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer{ Interval = TimeSpan.FromMicroseconds(10) };

        private double paddlespeed = 15;
        private Rectangle paddle1;
        private Rectangle paddle2;
        private Rectangle ball;

        public MainWindow()
        {
            InitializeComponent();
            paddle1 = creatPaddle(20,100);
            paddle2 = creatPaddle(20,100);
            ball = creatPaddle(15, 15);
            GameCanvas.Children.Add(paddle1);
            GameCanvas.Children.Add(paddle2);
            Loaded += new RoutedEventHandler(WindowLoaded);
            SizeChanged += new SizeChangedEventHandler(HandleSizeChangedEvent);
        }

        private void HandleSizeChangedEvent(object sender, SizeChangedEventArgs e)
        {
            setPosition();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

            setPosition();

        }


        public void ballmove()
        {

        }

        public void setPosition()
        {
            Canvas.SetLeft(paddle1, 10);
            Canvas.SetRight(paddle2, 10);
            Canvas.SetTop(paddle1, 10);
            Canvas.SetTop(paddle2, 10);
        }

        public void HandleKeyDown(object sender, KeyEventArgs e)
        {
            double p1top = Canvas.GetTop(paddle1);
            double p2top = Canvas.GetTop(paddle2);

            if (e.Key == Key.W && p1top > 0)
            {
                Canvas.SetTop(paddle1, p1top - paddlespeed);
            }
            if (e.Key == Key.S && p1top < (GameCanvas.ActualHeight - paddle1.ActualHeight))
            {
                Canvas.SetTop(paddle1, p1top + paddlespeed);
            }
            if (e.Key == Key.Up && p2top > 0)
            {
                Canvas.SetTop(paddle2, p2top - paddlespeed);
            }
            if (e.Key == Key.Down && p2top < (GameCanvas.ActualHeight - paddle2.ActualHeight))
            {
                Canvas.SetTop(paddle2, p2top + paddlespeed);
            }
        }


        public Rectangle creatPaddle(int Width, int Height)
        {
            return new Rectangle()
            {
                Width = Width,
                Height = Height,
                Fill = Brushes.Teal

            };
        }
    } 
}