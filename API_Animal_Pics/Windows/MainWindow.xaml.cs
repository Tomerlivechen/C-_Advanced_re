﻿using API_Animal_Pics.Windows;
using Common_Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using API_Animal_Pics.Classes;
using Common_Classes.Classes;
namespace API_Animal_Pics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        ObservableCollection<Animallist> listOfAnimalPicLists = new ObservableCollection<Animallist>();
        ICollectionView ImageSetsView;
        public MainWindow()
        {
            InitializeComponent();
            GlobalVars.LoadPicLists();
            


            ///           Activated += Window_Activated;
            ///           Closed += Window_Closed;

            ImageSetsView = CollectionViewSource.GetDefaultView(listOfAnimalPicLists);
            ImageListDataGrid.ItemsSource = ImageSetsView;
            updateLists();
            Activated += Window_Activated;
            Closed += Window_Closed;
        }

        public void Window_Activated(object sender, EventArgs e)
        {
            updateLists();
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Save before closeing?", "Close");
            if (respons == 1)
            {

                GlobalVars.SavePiclists();
                GlobalVars.CheckDuplicate();
            }
            else { return; }
        }

        private void Add_new_list_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.AddPicList();
            updateLists();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        public void updateLists()
        {
            listOfAnimalPicLists.Clear();
            foreach (Animallist tasklist in GlobalVars.animalPiclists.animalPiclists)
            {
                listOfAnimalPicLists.Add(tasklist);
            }
            ImageSetsView.Refresh();
            ImageListDataGrid.ItemsSource = ImageSetsView;

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Animallist Selectd_List = ImageListDataGrid.SelectedItem as Animallist;
            if (Selectd_List != null)
            {
                Delete_item(Selectd_List);
            }
        }
        private void Delete_item(Animallist Selectd_List)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Are you sure you want to delete this picture list?", "Deleting picture list");
            if (respons == 1)
            {
                List<Animallist> listOfpicLists = ImageSetsView.SourceCollection.Cast<Animallist>().ToList();
                Animallist picListToRemove = listOfpicLists.FirstOrDefault(item => item.Name == Selectd_List.Name);

                if (picListToRemove != null)
                {
                    listOfpicLists.Remove(picListToRemove);
                    ImageSetsView = CollectionViewSource.GetDefaultView(listOfpicLists);
                    ImageSetsView.Refresh();
                    ImageListDataGrid.ItemsSource = ImageSetsView;

                }
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Animallist Selectd_List = ImageListDataGrid.SelectedItem as Animallist;
            if (Selectd_List != null)
            {
                Random_image window = new Random_image(Selectd_List);
                window.ShowDialog();
            }
            if (Selectd_List == null)
            {
                Add_new_list_Click(sender, e);
            }
            updateLists();
        }

        private void View_Button_Click(object sender, RoutedEventArgs e)
        {
            Animallist Selectd_List = ImageListDataGrid.SelectedItem as Animallist;
            Saved_pics window = new Saved_pics(Selectd_List);
            window.ShowDialog();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.SavePiclists();
            GlobalVars.CheckDuplicate();
        }
    }
}