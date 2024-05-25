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
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
 //           Static_Data.LoadStoredDataBase();
  //          LoadDataBase();
        }

        public void LoadDataBase()
        {
            
        }

        

        async Task<List<DB_Item>> GetUsersAsync()
        {
            var response = await client.GetAsync(apiResource);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<DB_Item>>();
            getComboBoxes(data);
            return data;
        }

        async void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            var apiReponse = await GetUsersAsync();
            RawProductList = apiReponse;
            resultsDataGrid.ItemsSource = RawProductList;

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

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Deleted items cannot be retreved are you sure", "Deleting an item");
            if (respons == 1)
            {
                if (resultsDataGrid.SelectedItem is DB_Item itemToDelete)
                {
                    await client.DeleteAsync($"{apiResource}/{itemToDelete.ID}");

                    Load_Button_Click(sender, e);
                }
                return;
            }
            if (respons == 2)
            {
            return;
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

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
                    ComboBoxItem comboBoxsender = (ComboBoxItem)comboBox.SelectedItem;
                    if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                    {
                        var result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() select items;
                        resultsDataGrid.ItemsSource = result;
                        return;
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
                ComboBoxItem comboBoxsender = (ComboBoxItem)comboBox.SelectedItem;
                if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                {
                    var result = from items in RawProductList where items.MainCategory == comboBoxsender.Tag.ToString() select items;
                    resultsDataGrid.ItemsSource = result;
                }
            }
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

    }
}