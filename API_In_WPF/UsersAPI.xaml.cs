﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace API_In_WPF;

/// <summary>
/// Interaction logic for UsersAPI.xaml
/// </summary>
public partial class UsersAPI : Window
{
    private HttpClient client = new HttpClient();

    public UsersAPI()
    {
        InitializeComponent();
        client.BaseAddress = new Uri("https://reqres.in/api/");
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        UsersResponse usersReponse = await GetUsersAsync();

        UsersListBox.ItemsSource = usersReponse.Users;
    }

    private async Task<UsersResponse> GetUsersAsync()
    {
        HttpResponseMessage response = await client.GetAsync("users");
        response.EnsureSuccessStatusCode();
        UsersResponse data = await response.Content.ReadFromJsonAsync<UsersResponse>();

        return data;
    }
}

public class UsersResponse
{
    [JsonPropertyName("data")]
    public List<User> Users { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }
}

public class User
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("avatar")]
    public string Image { get; set; }
}
