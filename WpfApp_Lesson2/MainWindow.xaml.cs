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

namespace WpfApp_Lesson2
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

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {
            /*int col = (int)CostumerListMainGrid.GetValue(Grid.ColumnProperty);
            int newCol = col == 0 ? 1 : 0;
            CostumerListMainGrid.SetValue(Grid.ColumnProperty, newCol);
            CostumerFormMainStack.SetValue(Grid.ColumnProperty, col);*/
            //both option do the same

            int col1 = Grid.GetColumn(CostumerListMainGrid);
            int newCol1 = col1 == 0 ? 1 : 0;
            Grid.SetColumn(CostumerListMainGrid, newCol1);
            Grid.SetColumn(CostumerFormMainStack, col1);

            if (RighttPanel.Width == new GridLength(1, GridUnitType.Auto))
            {
                LeftPanel.Width = new GridLength(1, GridUnitType.Auto);
                RighttPanel.Width = new GridLength(4, GridUnitType.Star);
            }
            else
            {
                LeftPanel.Width = new GridLength(4, GridUnitType.Star);
                RighttPanel.Width = new GridLength(1, GridUnitType.Auto);
            }
        }
    }
}
