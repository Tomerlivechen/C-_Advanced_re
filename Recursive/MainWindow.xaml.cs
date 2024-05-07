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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recursive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(UserInput.Text, out int number);
            Result.Text =recursionFactor(number).ToString();


            
        }


        public double recursionFactor (double number)
        {
            if (number == 1) {
                return 1;
            }
            if (number > 1)
            {
                return number * recursionFactor(number-1);
            }
           return 0;
        }
    }
}