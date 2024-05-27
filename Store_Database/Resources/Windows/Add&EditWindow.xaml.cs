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
            getComboBoxes();

            if (addOrEdit == "Edit" ) {
                Title.Content = "Edit Item";
                Catagories1.SelectedItem = GetComboBoxItem(Catagories1, dB_Item.MainCategory);
                Catagories2.SelectedItem = GetComboBoxItem(Catagories2, dB_Item.SeconderyCategory);
                ItemName_text.Text = dB_Item.ItemName.ToString();
                Amount_text.Text = dB_Item.Amount.ToString();
                MinAmount_text.Text = dB_Item.MinAmount.ToString();
            }else
            {
                Title.Content = "Add New Item";
            }
        }

        public void getComboBoxes()
        {

            addToComboBox(Catagories1, Static_Data.MainCatagories);
            addToComboBox(Catagories2, Static_Data.SeconderyCatagories);

        }

        public ComboBoxItem? GetComboBoxItem( ComboBox combo,  string tag)
        {
            foreach (ComboBoxItem item in combo.Items)
            {
                if (item.Tag == tag)
                {
                    return item;
                }
            }
            return null;
        }

        public void addToComboBox(ComboBox comboBox, List<Categories> categories)
        {
            foreach (Categories title in categories)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem() { Content = title.Name.ToString(), Tag = title.Name.ToString() };
                comboBox.Items.Add(comboBoxItem);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AddorEdit == "Edit")
            {
                if (!string.IsNullOrEmpty(Catagories1_text.Text))
                {
                    Item.ChangeCat1(Catagories1_text.Text.ToString());
                }
                else
                {
                    if (Catagories1.SelectedItem is ComboBoxItem comboBoxItem)
                    {
                        Item.ChangeCat1(comboBoxItem.Tag.ToString());
                    }
                }
                if (!string.IsNullOrEmpty(Catagories2_text.Text))
                {
                    Item.ChangeCat2(Catagories2_text.Text.ToString());
                }
                else
                {
                    if (Catagories2.SelectedItem is ComboBoxItem comboBoxItem)
                    {
                        Item.ChangeCat1(comboBoxItem.Tag.ToString());
                    }
                }

                if (!string.IsNullOrEmpty(ItemName_text.Text.ToString()))
                {
                    Item.ItemName = ItemName_text.Text.ToString();
                }

                if (double.TryParse(Amount_text.Text.ToString(), out double amount)){
                    Item.AddAmount(amount);
                }
                else
                {
                    MessageBox.Show("Amount must be a number");
                    return;
                }

                if (double.TryParse(MinAmount_text.Text.ToString(), out double minamount))
                {
                    Item.UpdateMinAmount(minamount);
                }
                else
                {
                    MessageBox.Show("Minumum amount must be a number");
                    return;
                }

                if (!string.IsNullOrEmpty(Updater_text.Text.ToString()))
                {
                    bool updaterValid = false;
                foreach (Users user in Static_Data.ShopWorkors)
                {
                    if (user.ID.ToString() == Updater_text.Text.ToString())
                        {
                            updaterValid = true;
                            Item.LastUpdater = Updater_text.Text.ToString();
                        }
                }
                    if (updaterValid == false) {
                        MessageBox.Show("Invalid worker ID");
                        return;
                    }        }
                else
                {
                    MessageBox.Show("Must give a vlaid worker ID");
                    return;
                }

                Static_Data.BDItem = Item;
                Close();
            }

            if (AddorEdit == "ADD")
            {
                if (!string.IsNullOrEmpty(Catagories1_text.Text))
                {
                    Item.ChangeCat1(Catagories1_text.Text.ToString());
                }
                else
                {
                    Item.ChangeCat1(Catagories1.SelectedItem.ToString());
                }
                if (!string.IsNullOrEmpty(Catagories2_text.Text))
                {
                    Item.ChangeCat2(Catagories2_text.Text.ToString());
                }
                else
                {
                    Item.ChangeCat2(Catagories2.SelectedItem.ToString());
                }
                if (!string.IsNullOrEmpty(ItemName_text.Text.ToString())) {
                    Item.ItemName = ItemName_text.Text.ToString();
                }
                else
                {
                    MessageBox.Show("Item Must have a name");
                    return;
                }

                if (double.TryParse(Amount_text.Text.ToString(), out double amount))
                {
                    Item.AddAmount(amount);
                }
                else
                {
                    MessageBox.Show("Amount must be a number");
                    return;
                }

                if (double.TryParse(MinAmount_text.Text.ToString(), out double minamount))
                {
                    Item.UpdateMinAmount(minamount);
                }
                else
                {
                    MessageBox.Show("Minumum amount must be a number");
                    return;
                }

                if (!string.IsNullOrEmpty(Updater_text.Text.ToString()))
                {
                    bool updaterValid = false;
                    foreach (Users user in Static_Data.ShopWorkors)
                    {
                        if (user.ID.ToString() == Updater_text.Text.ToString())
                        {
                            if (user.StillEmployed ==true)
                            {
                                updaterValid = true;
                                Item.LastUpdater = Updater_text.Text.ToString();
                                break;
                            }
                            if (user.StillEmployed == false)
                            {
                                MessageBox.Show("This worker dosen't work here any more");
                                return;
                            }

                        }
                    }
                    if (updaterValid == false)
                    {
                        MessageBox.Show("Invalid worker ID");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Must give a vlaid worker ID");
                    return;
                }

                Static_Data.BDItem = new DB_Item(Item.ItemName, Item.MainCategory, Item.SeconderyCategory, Item.Amount, Item.MinAmount, Item.LastUpdater);
                Close();
            }


        }
    }
}
