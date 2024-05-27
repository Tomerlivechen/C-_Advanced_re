using Store_Database.Resources.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Store_Database.Resources.Classes;
using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using Store_Database.Resources.Windows;

namespace Store_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public List<DB_Item> RawProductList;
        Uri apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        string apiResource = "Store_items";
        string apiUsers = "Users";
        public DB_Item tempDbItem;
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
            LoadUsers();
            API_Static.InitializeAPI();
        }


        public void InitializeVars()
        {

        }

        async void LoadUsers()
        {
            var response = await client.GetAsync(apiUsers);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Users>>();
            Static_Data.ShopWorkors = data;
        }

        

        async Task<List<DB_Item>> GetUsersAsync()
        {
            var response = await client.GetAsync(apiResource);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<DB_Item>>();
            return data;
        }

        async void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            var apiReponse = await GetUsersAsync();
            RawProductList = apiReponse;
            resultsDataGrid.ItemsSource = RawProductList;
            getComboBoxes(apiReponse);

        }

        public void getComboBoxes(List<DB_Item> dB_Items)
        {
            var resultMainCategory = from item in dB_Items 
                         select new Categories
                         {
                             Name = item.MainCategory
                         };

            Static_Data.MainCatagories = resultMainCategory.ToList();

            var resultSeconderyCatagories = from item in dB_Items
                                            select new Categories
                                            {
                                                Name = item.SeconderyCategory
                                     };

            Static_Data.SeconderyCatagories = resultSeconderyCatagories.ToList();


            addToComboBox(Catagories1, Static_Data.MainCatagories);
            addToComboBox(Catagories2, Static_Data.SeconderyCatagories);
        }

        public void addToComboBox(ComboBox comboBox , List<Categories> categories )
        {
            foreach (Categories title in categories)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem() { Content= title.Name.ToString(), Tag= title.Name.ToString() };
                comboBox.Items.Add( comboBoxItem );
            }
        }

        async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add_EditWindow add_EditWindow = new Add_EditWindow(tempDbItem, "Add");
            add_EditWindow.ShowDialog();
            if (Static_Data.BDItem.ItemName != null)
            {
                await client.PostAsJsonAsync(apiResource, Static_Data.BDItem);
                Log.addToLog($"{Static_Data.BDItem.ToString()} Added");
                Static_Data.BDItem = null;
                Load_Button_Click(sender, e);
            }
            else
            {
                MessageBox.Show("No Item Added","Error");
            }

        }

        async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Deleted items cannot be retreved are you sure", "Deleting an item");
            if (respons == 1)
            {
                if (resultsDataGrid.SelectedItem is DB_Item itemToDelete)
                {
                    if (Security.checkManagerCode())
                    {
                        await client.DeleteAsync($"{apiResource}/{itemToDelete.ID}");
                        Log.addToLog($"{itemToDelete.ToString()} Deleted");
                        Load_Button_Click(sender, e);
                    }

                }
                return;
            }
            if (respons == 2)
            {
            return;
            }
        }

        async void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

            if (resultsDataGrid.SelectedItem != null)
            {
                DB_Item dB_Item = resultsDataGrid.SelectedItem as DB_Item;
                Add_EditWindow add_EditWindow = new Add_EditWindow(dB_Item, "Edit");
                add_EditWindow.ShowDialog();
                if (Static_Data.BDItem.ItemName != null)
                {
                    await client.PutAsJsonAsync($"{apiResource}/{Static_Data.BDItem.ID}", Static_Data.BDItem);
                    Log.addToLog($"{Static_Data.BDItem.ToString()} Edited");
                    Static_Data.BDItem = null;
                    Load_Button_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Item Error", "Error");
                }
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Search.Text.ToString()))
            {
                var result = from items in RawProductList where items.ItemName.ToUpper().Contains(Search.Text.ToUpper().ToString()) select items;
                resultsDataGrid.ItemsSource = result;
                return;
            }
        }

        private void Undermin_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = from items in RawProductList where items.MinAmount> items.Amount select items;
            resultsDataGrid.ItemsSource = result;
            return;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Catagories2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Catagories1.SelectedIndex == 0)
            {

                if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    if (comboBox.SelectedItem is ComboBoxItem comboBoxsender && comboBoxsender.Tag != null)
                    {
                        if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                        {
                            var result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() select items;
                            resultsDataGrid.ItemsSource = result;
                            return;
                        }
                    }
                }
            }
            else
            {
                if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
                {
                    ComboBoxItem comboBoxsender = (ComboBoxItem)comboBox.SelectedItem;
                    ComboBoxItem comboBoxmain = (ComboBoxItem)Catagories1.SelectedItem;
                    if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                    {
                        var result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() && items.MainCategory == comboBoxmain.Tag.ToString() select items;
                        resultsDataGrid.ItemsSource = result;
                        if (result.Count() < 1)
                        {
                            result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() select items;
                            resultsDataGrid.ItemsSource = result;
                            Catagories1.SelectedIndex = 0;
                            return;
                        }
                    }
                }
            }

        }

        private void Catagories1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                if (comboBox.SelectedItem is ComboBoxItem comboBoxsender && comboBoxsender.Tag != null) { 
                if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                {
                    var result = from items in RawProductList where items.MainCategory == comboBoxsender.Tag.ToString() select items;
                    resultsDataGrid.ItemsSource = result;
                }
            }
            }
        }





        private void ChangeAPIAddress_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                API_Static.ChangeAPIAddress_Click();
                apiadress = API_Static.apiadress;
                apiResource = API_Static.apiResource;
            }


        }

        private void ChangePasscode_Click(object sender, RoutedEventArgs e)
        {
            Security.changeManagerCode();
        }

        private void VeiwWorkers_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                UsersWindow usersWindow = new UsersWindow();
                usersWindow.ShowDialog();
            }
        }
    }
}