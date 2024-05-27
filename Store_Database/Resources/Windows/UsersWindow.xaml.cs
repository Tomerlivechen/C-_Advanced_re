using Store_Database.Resources.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Windows.Xps.Packaging;

namespace Store_Database.Resources.Windows
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        HttpClient client = new HttpClient();
        Uri apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        string apiUsers = "Users";
        public UsersWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
            UserGrid.ItemsSource = Static_Data.ShopWorkors;
        }

        async void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem != null)
            {
                Static_Data.tempUser = null;
                Static_Data.tempUser2 = null;
                Users user = UserGrid.SelectedItem as Users;
                Add_EditUserWindow add_EditUserWindow = new Add_EditUserWindow(user, "Edit");
                add_EditUserWindow.ShowDialog();
                if (Static_Data.tempUser2.ID != null)
                {
                    await client.DeleteAsync($"{apiUsers}/{Static_Data.tempUser.ID}");
                    await client.PostAsJsonAsync(apiUsers, Static_Data.tempUser2);
                    Log.addToLog($"{Static_Data.tempUser2.ToString()} worker edited");
                    MessageBox.Show("Worker edited", "Success");
                    Static_Data.tempUser = null;
                    Static_Data.tempUser2 = null;
                    return;
                }
                if (Static_Data.tempUser2.ID == null && Static_Data.tempUser.ID != null)
                {
                    await client.PutAsJsonAsync($"{apiUsers}/{Static_Data.tempUser.ID}", Static_Data.tempUser);
                    Log.addToLog($"{Static_Data.tempUser.ToString()} worker edited");
                    MessageBox.Show("Worker edited", "Success");
                    Static_Data.tempUser = null ;
                    Static_Data.tempUser2 = null;
                    return;
                }
                else
                {
                    MessageBox.Show("Worker not edited", "Error");
                    Static_Data.tempUser = null;
                    Static_Data.tempUser2 = null;
                    return;
                }


            }
        }

        async void LoadUsers()
        {
            var response = await client.GetAsync(apiUsers);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Users>>();
            Static_Data.ShopWorkors = data;
            UserGrid.ItemsSource = Static_Data.ShopWorkors;
        }

        async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Static_Data.tempUser = null;
            Add_EditUserWindow add_EditUserWindow = new Add_EditUserWindow(Static_Data.tempUser, "Add");
            add_EditUserWindow.ShowDialog();
            if (Static_Data.tempUser.ID != null)
            {
                await client.PostAsJsonAsync(apiUsers, Static_Data.tempUser);
                Log.addToLog($"{Static_Data.tempUser.ToString()} worker added");
                Static_Data.tempUser = null;
                MessageBox.Show("Worker added", "Success");
                LoadUsers();
            }
            else
            {
                MessageBox.Show("No worker added", "Error");
            }


        }

        private void LetGo_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                if (UserGrid.SelectedItem != null)
                {
                    Users user = UserGrid.SelectedItem as Users;
                    user.LetGo();
                    Log.addToLog($"{user.ToString()} worker Let Go");
                    LoadUsers();
                }
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var result = from users in Static_Data.ShopWorkors where users.Name.ToUpper().Contains(Filter_Text.Text.ToUpper().ToString()) select users;
            UserGrid.ItemsSource = result;

        }

        private void Only_Managers_Click(object sender, RoutedEventArgs e)
        {

                var result = from users in Static_Data.ShopWorkors where users.Manager == true select users;
                UserGrid.ItemsSource = result;
        }

        private void Only_Workers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Only_Employed_Click(object sender, RoutedEventArgs e)
        {
            var result = from users in Static_Data.ShopWorkors where users.StillEmployed == true select users;
            UserGrid.ItemsSource = result;
        }
    }
}
