﻿using Store_Database.Resources.Classes;
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
    /// Interaction logic for Add_EditWindow.xaml
    /// </summary>
    public partial class Add_EditWindow : Window
    {
        DB_Item Item = new DB_Item();
        string AddorEdit;
        public Add_EditWindow(DB_Item dB_Item, string addOrEdit)
        {
            Item = dB_Item;
            AddorEdit  = addOrEdit;
            InitializeComponent();
            GetComboBoxes();
            if (addOrEdit == "Edit" ) {
                Title.Content = "Edit Item";
                Catagories1.Text =  Item.MainCategory;
                Catagories2.Text = Item.SeconderyCategory;
                ItemName_text.Text = dB_Item.ItemName;
                Amount_text.Text = dB_Item.Amount.ToString();
                MinAmount_text.Text = dB_Item.MinAmount.ToString();
            }else
            {
                Title.Content = "Add New Item";
                Item = new DB_Item();
            }
        }
        public void GetComboBoxes()
        {
            addToComboBox(Catagories1, Static_Data.MainCatagories);
            addToComboBox(Catagories2, Static_Data.SeconderyCatagories);
        }
        public ComboBoxItem? GetComboBoxItem( ComboBox combo,  string tag)
        {
            return combo.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Tag?.ToString() == tag);
                }

        public void addToComboBox(ComboBox comboBox, List<Categories> categories)
        {
            comboBox.Items.Clear();
            foreach (Categories title in categories)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem() { Content = title.Name, Tag = title.Name };
                comboBox.Items.Add(comboBoxItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAndSetLastUpdater())
            {
                if (AddorEdit == "Edit")
                {
                    UpdateItem();
                }
                else if (AddorEdit == "Add")
                {
                    AddItem();
                }
            }
        }
        private bool ValidateAndSetLastUpdater()
        {
            if (string.IsNullOrEmpty(Updater_text.Text))
            {
                MessageBox.Show("Must give a valid worker ID");
                return false;
            }

            bool updaterValid = false;
            foreach (var user in Static_Data.ShopWorkors)
            {
                if (user.ID == Updater_text.Text && user.StillEmployed)
                {
                    updaterValid = true;
                    Item.LastUpdater = Updater_text.Text;
                    break;
                }
            }

            if (!updaterValid)
            {
                MessageBox.Show("Invalid worker ID or worker is no longer employed");
                Log.addToLog("Invalid worker ID used");
                return false;
            }
            return true;
        }

        private void UpdateItem()
        {
            if (!string.IsNullOrEmpty(Catagories1_text.Text))
            {
                Item.ChangeCat1(Catagories1_text.Text);
            }
            else if (Catagories1.SelectedItem is ComboBoxItem comboCat1BoxItem)
            {
                Item.ChangeCat1(comboCat1BoxItem.Tag.ToString());
            }

            if (!string.IsNullOrEmpty(Catagories2_text.Text))
            {
                Item.ChangeCat2(Catagories2_text.Text);
            }
            else if (Catagories2.SelectedItem is ComboBoxItem comboCat2BoxItem)
            {
                Item.ChangeCat2(comboCat2BoxItem.Tag.ToString());
            }

            if (!string.IsNullOrEmpty(ItemName_text.Text))
            {
                Item.ItemName = ItemName_text.Text;
            }

            if (double.TryParse(Amount_text.Text, out double amount))
            {
                Item.AddAmount(amount);
            }
            else
            {
                MessageBox.Show("Amount must be a number");
                return;
            }

            if (double.TryParse(MinAmount_text.Text, out double minAmount))
            {
                Item.UpdateMinAmount(minAmount);
            }
            else
            {
                MessageBox.Show("Minimum amount must be a number");
                return;
            }

            Static_Data.BDItem = Item;
            Close();
        }

        private void AddItem()
        {
            if (!string.IsNullOrEmpty(Catagories1_text.Text))
            {
                Item.ChangeCat1(Catagories1_text.Text);
            }
            else if (Catagories1.SelectedItem is ComboBoxItem cat1BoxItem)
            {
                Item.ChangeCat1(cat1BoxItem.Tag.ToString());
            }

            if (!string.IsNullOrEmpty(Catagories2_text.Text))
            {
                Item.ChangeCat2(Catagories2_text.Text);
            }
            else if (Catagories2.SelectedItem is ComboBoxItem cat2BoxItem)
            {
                Item.ChangeCat2(cat2BoxItem.Tag.ToString());
            }

            if (!string.IsNullOrEmpty(ItemName_text.Text))
            {
                Item.ItemName = ItemName_text.Text;
            }
            else
            {
                MessageBox.Show("Item must have a name");
                return;
            }

            if (double.TryParse(Amount_text.Text, out double amount))
            {
                Item.AddAmount(amount);
            }
            else
            {
                MessageBox.Show("Amount must be a number");
                return;
            }

            if (double.TryParse(MinAmount_text.Text, out double minAmount))
            {
                Item.UpdateMinAmount(minAmount);
            }
            else
            {
                MessageBox.Show("Minimum amount must be a number");
                return;
            }
            Static_Data.BDItem = new DB_Item(Item.ItemName, Item.MainCategory, Item.SeconderyCategory, Item.Amount, Item.MinAmount, Item.LastUpdater);
            Close();
        }

        private void Catagories1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Catagories1_text.Text = string.Empty;
        }
        private void Catagories2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Catagories2_text.Text = string.Empty;
        }
    }
}
