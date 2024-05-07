using System.Net.Http;
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
using static System.Net.WebRequestMethods;

namespace API_In_WPF;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private HttpClient client = new HttpClient();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        string joke_type = "Any";
        if (JokeType.SelectedItem != null)
        {
            ComboBoxItem selectedItem = JokeType.SelectedItem as ComboBoxItem;
            joke_type = selectedItem.Content.ToString();
        }

        Textblock.Text = "Getting joke....";
        if (Clean.IsChecked == true)
        {
            try
            {
                string joke = await GetJokeFromAPI(joke_type);
                Textblock.Text = joke;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The joke is you, {ex}");
            }
        }
        else
        {
            try
            {
                string joke = await GetJokeSpecificFromAPI(joke_type);
                Textblock.Text = joke;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The joke is you, {ex}");
            };
        }
    }


    private async Task<string> GetJokeFromAPI(string type)
    {
        string response = await client.GetStringAsync($"https://v2.jokeapi.dev/joke/{type}");

        Joke? json = JsonSerializer.Deserialize<Joke>(response);

        if (json.joke == null)
        {
            string twoParter = $"{json.setup} \n {json.delivery}";
            return twoParter;
        }
        return json.joke;
    }

    private async Task<string> GetJokeSpecificFromAPI(string type)
    {
        Joke json;
        bool specificationsMet = false;
        do
        {
            string response = await client.GetStringAsync($"https://v2.jokeapi.dev/joke/{type}");

            json = JsonSerializer.Deserialize<Joke>(response);
            specificationsMet = CheckSpecifications(json);

        } while (!specificationsMet);

        if (json.joke == null)
        {
            string twoParter = $"{json.setup} \n {json.delivery}";
            return twoParter;
        }
        return json.joke;
    }

    public bool CheckSpecifications(Joke joke)
    {
        bool setsMatch = true;
        bool[] set1 = { (bool)nsfw.IsChecked, (bool)religious.IsChecked, (bool)political.IsChecked, (bool)racist.IsChecked, (bool)sexist.IsChecked };
        bool[] set2 = { joke.flags.nsfw, joke.flags.religious, joke.flags.political, joke.flags.racist, joke.flags.sexist };
        for (int i = 0; i < set1.Length; i++)
        {
            if (set1[i] != set2[i])
            {
                setsMatch = false;
                break;
            }
        }
        return setsMatch;
    }

    private void Clean_Checked(object sender, RoutedEventArgs e)
    {
        nsfw.IsChecked = false;
        religious.IsChecked = false;
        political.IsChecked = false;
        racist.IsChecked = false;
        sexist.IsChecked = false;
    }

    private void specifide_Checked(object sender, RoutedEventArgs e)
    {
        Clean.IsChecked = false;
    }
}
