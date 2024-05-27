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
        public string ManagerPassward = "0000";
        public DB_Item tempDbItem;
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
            LoadUsers();
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
                    if (checkManagerCode())
                    {
                        await client.DeleteAsync($"{apiResource}/{itemToDelete.ID}");
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


        public bool checkManagerCode()
        {
            bool hasInput = false;
            var number_of_field = 1;
            var title = "Manager Approval";
            var Input_field1 = new Input_box_field();
            Input_field1.Input_label = "Insert Manager Passcode";
            do
            {
                var input_Box = new Input_box(number_of_field, title, Input_field1);
                input_Box.ShowDialog();

                if (UniversalVars.inputBoxReturn.Count == 0 || string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) || string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString()) )
                {
                    hasInput = false;
                }
                if (UniversalVars.inputBoxReturn.Count == 1 && !string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) && !string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString()) )
                {
                    hasInput = true;
                }

            } while (!hasInput);
            if (UniversalVars.inputBoxReturn[0].ToString() == ManagerPassward)
            {
                return true;
            }
            MessageBox.Show("Wrong Passcode");
            return false;
        }


        private void ChangeAPIAddress_Click(object sender, RoutedEventArgs e)
        {
            bool hasInput=false;
            var number_of_field = 2;
            var title = "Insert your API info";
            var Input_field1 = new Input_box_field();
            var Input_field2 = new Input_box_field();
            Input_field1.Input_label = "Enter API Uri:";
            Input_field2.Input_label = "Enter API Resource:";
            do
            {
                var input_Box = new Input_box(number_of_field, title, Input_field1, Input_field2);
                input_Box.ShowDialog();

                if (UniversalVars.inputBoxReturn.Count == 0 || string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) || string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString())|| string.IsNullOrEmpty(UniversalVars.inputBoxReturn[1].ToString()) || string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[1].ToString()))
                {
                    hasInput=false ;
                }
                if (UniversalVars.inputBoxReturn.Count == 2 && !string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) && !string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString()) && !string.IsNullOrEmpty(UniversalVars.inputBoxReturn[1].ToString()) && !string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[1].ToString()))
                {
                    hasInput = true;
                }

            } while (!hasInput);
            apiResource = UniversalVars.inputBoxReturn[1].ToString();
            bool isUri = Uri.TryCreate(UniversalVars.inputBoxReturn[0] , UriKind.Absolute, out Uri? uriAPI);
            if (isUri && uriAPI != null) {
                apiadress = uriAPI;
                    }
            if (isUri != null) {
                MessageBox.Show("API adress invalid", "Invalid API");
            }

            

        }

        private void ChangePasscode_Click(object sender, RoutedEventArgs e)
        {
            bool hasInput = false;
            var number_of_field = 3;
            var title = "Insert New Manager passcode";
            var Input_field1 = new Input_box_field();
            var Input_field2 = new Input_box_field();
            var Input_field3 = new Input_box_field();
            Input_field1.Input_label = "Enter Manager edit passcode:";
            Input_field2.Input_label = "Enter Old Manager passcode:";
            Input_field3.Input_label = "Enter New Manager passcode:";
            do
            {
                var input_Box = new Input_box(number_of_field, title, Input_field1, Input_field2, Input_field3);
                input_Box.ShowDialog();

                if (UniversalVars.inputBoxReturn.Count == 3 )
                {
                    hasInput = true;
                }

            } while (!hasInput);

            if (UniversalVars.inputBoxReturn[0].ToString() == Static_Data.ManagerEditPassward)
            {
                if (UniversalVars.inputBoxReturn[1].ToString() == Static_Data.ManagerPassward)
                {
                    Static_Data.ManagerPassward = UniversalVars.inputBoxReturn[2].ToString();
                    MessageBox.Show("Passcode changed successfully", "success");
                    return;
                }
                MessageBox.Show("Manager passcode incorrect", "Error");
                return;


            }
            MessageBox.Show("Manager edit passcode incorrect", "Error");
            return;

        }

        private void VeiwWorkers_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.ShowDialog();
        }
    }
}