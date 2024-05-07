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

namespace WpfApp_Lesson_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter;
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
        private void _Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you have clicked the button");
            _Button1.Content = "I was the wrong button";
            _Button2.Content = "Click me";
        }

        private void _Button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (counter % 2 == 0)
            {
                _Button2.Content = "I am the wrong button";
                counter++;
                Thread.Sleep(500);
            }
            else
            {
                _Button2.Content = "My button 2";
                counter++;
                Thread.Sleep(500);
            }
        }*/
    }
}