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
                Start_text.DisplayDate = user.StartDate;
                if (user.EndDate != null)
                {
                    End_text.DisplayDate = (DateTime)user.EndDate;
                }
                Manager_Check.IsChecked = user.Manager;
                Still_Check.IsChecked = user.Manager;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                if (AddorEdit == "Edit" && ID_text.Text != Import_user.ID.ToString())
                {
                    Static_Data.tempUser = Import_user;
                    Static_Data.tempUser2 = new Users() { ID = ID_text.Text, Name = Name_text.Text, StartDate = (DateTime)Start_text.DisplayDate, StillEmployed = (bool)Still_Check.IsChecked, Manager = (bool)Manager_Check.IsChecked, EndDate = End_text.DisplayDate };
                    Close();
                    return;
                }
                if (AddorEdit == "Edit" && ID_text.Text == Import_user.ID.ToString())
                {

                    Static_Data.tempUser = new Users() { ID = ID_text.Text, Name = Name_text.Text, StartDate = (DateTime)Start_text.DisplayDate, StillEmployed = (bool)Still_Check.IsChecked, Manager = (bool)Manager_Check.IsChecked, EndDate = End_text.DisplayDate };
                }

                if (AddorEdit == "Add")
                {

                    bool isRepeatID = false;
                    foreach (Users user in Static_Data.ShopWorkors)
                    {
                        if (user.ID == ID_text.Text)
                        {
                            isRepeatID = true;
                            MessageBox.Show("The ID is alredy in use");
                            break;
                        }
                    }
                    if (isRepeatID == false)
                    {
                        Static_Data.tempUser = new Users() { ID = ID_text.Text, Name = Name_text.Text, StartDate = (DateTime)Start_text.DisplayDate, StillEmployed = (bool)Still_Check.IsChecked, Manager = (bool)Manager_Check.IsChecked, EndDate = End_text.DisplayDate };
                        Close();
                        return;
                    }


                }

            }
        }

    }
}
