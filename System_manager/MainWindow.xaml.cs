using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System_manager.Resources;
using Common_Classes;
using System.ComponentModel;
using System.Xml.Linq;
using System;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace System_manager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private const string filePath = (@"Resources\People.json");

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool autosave = true;

    DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(30) };


    ICollectionView peopleView;

    ObservableCollection<Person> people = new ObservableCollection<Person>();
    private ObservableCollection<Person> People
    {
        get => people;
        set
        {
            people = value;
            OnPropertyChanged(nameof(People));
        }
    }

    public MainWindow()
    {
        InitializeComponent();

        peopleView = CollectionViewSource.GetDefaultView(people);

        LoadData();

        PeopleDataGrid.ItemsSource = peopleView;

        timer.Tick += (sender, e) =>
        {
            if (autosave)
                Save();
        };

        timer.Start();
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void LoadData()
    {
        if (!File.Exists(filePath))
        {
            return;
        }
        try
        {
            string rawData = File.ReadAllText(filePath);

            List<Person>? result = JsonSerializer.Deserialize<List<Person>>(rawData);
            if (result == null)
            {
                return;
            }
            foreach (Person person in result)
            {
                people.Add(person);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"File reading error {ex.Message}");
        }
    }

    public void Update_Button_Click(object sender, RoutedEventArgs e)
    {
        Save();
    }

    public void Save()
    {
        string export = JsonSerializer.Serialize(People);
        File.WriteAllText(filePath, export);
        people.Clear();
        LoadData();
        Update_Data_Grid();
    }

    private void Add_Button_Click(object sender, RoutedEventArgs e)
    {
        if (
            Foolproofing.ValueVarification(1, 200, TB_Age.Text, "Age out of bounds")
            && !Check_double(TB_ID.Text)
        )
        {
            int.TryParse(TB_Age.Text, out int personAge);
            Person person = new Person(TB_ID.Text, TB_Name.Text, personAge);
            People.Add(person);
            Update_Data_Grid();
            TB_ID.Text = "";
            TB_Name.Text = "";
            TB_Age.Text = null;
        }
    }

    public void Update_Data_Grid()
    {
        PeopleDataGrid.Items.Refresh();
    }

    private void Clear_Button_Click(object sender, RoutedEventArgs e)
    {
        PeopleDataGrid.SelectedItem = null;
    }

    public bool Check_double(string Nwe_ID)
    {
        List<string> ID_List = Make_ID_to_array();
        foreach (string ID in ID_List)
        {
            if (ID == Nwe_ID)
            {
                MessageBox.Show($"ID value {Nwe_ID} alredy in use");
                return true;
            }
        }
        return false;
    }

    public List<string> Make_ID_to_array()
    {
        List<string> ID_list = new List<string>();
        foreach (Person person in people)
        {
            ID_list.Add(person.ID);
        }
        return ID_list;
    }

    private void Remove_Button_Click(object sender, RoutedEventArgs e)
    {
        Person Selectd_person = PeopleDataGrid.SelectedItem as Person;
        Delete_item(Selectd_person);
        Update_Data_Grid();
    }

    public void Delete_item(Person Selectd_person)
    {
        people.Remove(Selectd_person);
    }


    private void AutoSave_Click(object sender, RoutedEventArgs e)
    {
        autosave = !autosave;
    }

    private void Handle_Delete(object sender, RoutedEventArgs e)
    {
        MessageBoxResult resuly = MessageBox.Show("Are you sure you want to delete?", "Delete object", MessageBoxButton.YesNo);
        if (resuly == MessageBoxResult.Yes)
        {
            Button btn = sender as Button;
            if (btn == null) { return; };
            if (btn.DataContext is Person person_to_delete)
            {
                Delete_item(person_to_delete);
            }
        }
        else
        {
            return;
        }
    }

    private void TB_Filter_KeyUp(object sender, KeyEventArgs e)
    {
        string filterString = TB_Filter.Text.ToLower();

        peopleView.Filter = o =>
        {
            if (o is Person persontofilter)
            {
                return persontofilter.name.ToLower().Contains(filterString);
            }
            return false;
        };
    }

    private void TB_Filter_GotFocus(object sender, RoutedEventArgs e)
    {
        if (TB_Filter.Text== "Filter...") { return; };

        TB_Filter.Text = "";
    }

    private void TB_Filter_LostFocus(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TB_Filter.Text)) { return; };
        TB_Filter.Text = "Filter...";

    }
}
