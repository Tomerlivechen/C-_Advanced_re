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

namespace Advanced_Lesson_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Subclass> classList = Subclass.GetListFromFile();

            GridItems.ItemsSource = classList;
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            Subclass selectedItem = GridItems.SelectedItem as Subclass;

            if (selectedItem == null)
            {
                MessageBox.Show("No item selected");
                return;
            }

            ItemDisplay itemDysplay = new ItemDisplay(selectedItem);
             itemDysplay.Owner = this;
            itemDysplay.Show();
        }
    }
}

