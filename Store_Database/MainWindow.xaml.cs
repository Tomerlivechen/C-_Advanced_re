using Store_Database.Resources.Classes;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public List<DB_Item> RawProductList;
        public MainWindow()
        {
            InitializeComponent();
            Static_Data.LoadStoredDataBase();
            LoadDataBase();
        }

        public void LoadDataBase()
        {
            RawProductList = Static_Data.BDItems;
        }
    }
}