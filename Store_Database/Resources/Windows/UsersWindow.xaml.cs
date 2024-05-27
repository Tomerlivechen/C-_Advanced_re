using Store_Database.Resources.Classes;
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

namespace Store_Database.Resources.Windows
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            UserGrid.ItemsSource = Static_Data.ShopWorkors;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem != null)
            {
                Users user = UserGrid.SelectedItem as Users;
                Add_EditUserWindow add_EditUserWindow = new Add_EditUserWindow(user, "Edit");
                add_EditUserWindow.ShowDialog();
            }
        }


        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LetGo_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
