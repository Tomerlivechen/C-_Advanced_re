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

namespace API_In_WPF
{
    /// <summary>
    /// Interaction logic for Mock_API_Users.xaml
    /// </summary>
    public partial class Mock_API_Users : Window
    {
        HttpClient client = new HttpClient();
        public Mock_API_Users()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            var usersReponse = await GetUsersAsync();

            UsersListBox.ItemsSource = usersReponse;
        }

        async Task<List<MockUser>> GetUsersAsync()
        {
            var response = await client.GetAsync("Users");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<MockUser>>();

            return data;
        }

        async void Button_Click_Uplead(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var addedUser = new MockUser { ID = random.Next(UsersListBox.Items.Count, 200), Name = TB_Name.Text, Email = TB_Email.Text, Image = Getimage.GetBearimage() };

            await client.PostAsJsonAsync("Users", addedUser);

            Button_Click(sender, e);
        }

        async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is MockUser userToUpdate)
            {
                userToUpdate.Email = TB_Email.Text;
                userToUpdate.Name = TB_Name.Text;

                await client.PutAsJsonAsync($"Users/{userToUpdate.ID}", userToUpdate);

                Button_Click(sender, e);
            }
        }

        async void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is MockUser userToDelete)
            {
                userToDelete.Email = TB_Email.Text;
                userToDelete.Name = TB_Name.Text;

                await client.DeleteAsync($"Users/{userToDelete.ID}");

                Button_Click(sender, e);
            }
        }
    }

    public static class Getimage
    {
        public static string GetBearimage()
        {
            var random = new Random();
            var size = random.Next(100, 500);
            return $"https://placebear.com/{size}/{size}.jpg";
        }
    }

    public class MockUser
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar")]
        public string Image { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}