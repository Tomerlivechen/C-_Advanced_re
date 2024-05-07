using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace API_In_WPF
{
    /// <summary>
    /// Interaction logic for Cat_Or_Dog.xaml
    /// </summary>
    public partial class Cat_Or_Dog : Window
    {
        private HttpClient client = new HttpClient();
        public Cat_Or_Dog()
        {
            InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            string Animalimage = await GetPicAPI(button.Tag.ToString());
            SetImageSource(Animalimage);
        }

        private async Task<string> GetPicAPI(string type)
        {
            string response = "";
            if (type == "Dog") { response = await client.GetStringAsync($"https://api.thedogapi.com/v1/images/search"); }
            if (type == "Cat") { response = await client.GetStringAsync($"https://api.thecatapi.com/v1/images/search"); }

            if (type == "Fox") {
                response = await client.GetStringAsync($"https://randomfox.ca/floof/?ref=apilist.fun");
                AnimalPic? Foxjson = JsonSerializer.Deserialize<AnimalPic>(response);
                return Foxjson.image;
            }

            if (type == "Bear")
            {
                Random random = new Random();
                int width = random.Next(100,500);
                int hight = random.Next(100, 500);
                return $"https://placebear.com/{width}/{hight}.jpg";
            }

            List<AnimalPic>? json = JsonSerializer.Deserialize<List<AnimalPic>>(response);

            return (json[0].url);
        }

        private void SetImageSource(string imageUrl)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageUrl);
                bitmap.EndInit();

                Animal_pic.Source = bitmap;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

    }
}
