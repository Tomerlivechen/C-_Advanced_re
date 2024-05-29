using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Store_Database.Resources.Classes
{
    public static class API_Static
    {
        public static Uri apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        public static string apiResource = "Store_items";
        public static string apiFilePath = "Resources/APIAdress.json";
        public static string apiResourceFilePath = "Resources/APIResource.json";

        public static void ChangeAPIAddress_Click()
        {
            bool hasInput = false;
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

                if (UniversalVars.inputBoxReturn.Count == 0 || string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) || string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString()) || string.IsNullOrEmpty(UniversalVars.inputBoxReturn[1].ToString()) || string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[1].ToString()))
                {
                    hasInput = false;
                }
                if (UniversalVars.inputBoxReturn.Count == 2 && !string.IsNullOrEmpty(UniversalVars.inputBoxReturn[0].ToString()) && !string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[0].ToString()) && !string.IsNullOrEmpty(UniversalVars.inputBoxReturn[1].ToString()) && !string.IsNullOrWhiteSpace(UniversalVars.inputBoxReturn[1].ToString()))
                {
                    hasInput = true;
                }

            } while (!hasInput);
            apiResource = UniversalVars.inputBoxReturn[1].ToString();
            bool isUri = Uri.TryCreate(UniversalVars.inputBoxReturn[0], UriKind.Absolute, out Uri? uriAPI);
            if (isUri && uriAPI != null)
            {
                apiadress = uriAPI;
                Log.addToLog($"API changed to {uriAPI}/{apiResource}");
                SaveAPIStats();
                return;
            }
            if (isUri != null)
            {
                MessageBox.Show("API adress invalid", "Invalid API");
                Log.addToLog($"API changed atempted");
                return;
            }
        }

        public static void InitializeAPI()
        {
            LoadAPI();
            LoadAPIResource();
        }
        public static void SaveAPIStats()
        {
            SaveAPI();
            SaveAPIResource();
        }

        public static void LoadAPI()
        {
            if (!File.Exists(apiFilePath))
            {
                Uri APIAdress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
                apiadress = APIAdress;
                SaveAPI();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(apiFilePath);
                var result = JsonSerializer.Deserialize<Uri>(rawData);
                if (result == null)
                {
                    Uri APIAdress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
                    apiadress = APIAdress;
                    SaveAPI();
                    return;
                }
                apiadress = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }

        public static void SaveAPI()
        {
            var export = JsonSerializer.Serialize(apiadress);
            try
            {
                string directoryPath = Path.GetDirectoryName(apiFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(apiFilePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadAPI();
        }

        public static void LoadAPIResource()
        {
            if (!File.Exists(apiResourceFilePath))
            {
                string APIResource = "Store_items";
                apiResource = APIResource;
                SaveAPIResource();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(apiResourceFilePath);
                var result = JsonSerializer.Deserialize<string>(rawData);
                if (result == null)
                {
                    string APIResource = "Store_items";
                    apiResource = APIResource;
                    SaveAPIResource();
                    return;
                }
                apiResource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }

        public static void SaveAPIResource()
        {
            var export = JsonSerializer.Serialize(apiResource);
            try
            {
                string directoryPath = Path.GetDirectoryName(apiResourceFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(apiResourceFilePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadAPIResource();
        }
    }
}
