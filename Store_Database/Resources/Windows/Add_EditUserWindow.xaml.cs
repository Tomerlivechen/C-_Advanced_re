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
    /// Interaction logic for Add_EditUserWindow.xaml
    /// </summary>
    public partial class Add_EditUserWindow : Window
    {
        Users Import_user = new Users();
        string AddorEdit;
        public Add_EditUserWindow(Users user, string addOrEdit) {
            Import_user = user;
            AddorEdit = addOrEdit;
            InitializeComponent();
            if (addOrEdit == "Edit" ) {

                ID_text.Text = user.ID.ToString();
                Name_text.Text=user.Name.ToString();
                Start_text.Text = user.StartDate.ToString();

                if (user.EndDate != null)
                {
                    End_text.Text = user.EndDate.ToString();
                }
                Manager_Check.IsChecked = user.Manager;
                Still_Check.IsChecked = user.Manager;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
