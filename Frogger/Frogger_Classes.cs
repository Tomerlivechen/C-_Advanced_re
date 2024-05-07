using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.Json;
using System.Windows;
using Common_Classes;
using Common_Classes.Common_Elements;

namespace Frogger
{
    public static class Frogger_Classes
    {
        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/{resourceName}"
            );

            return new BitmapImage(uri);
        }
    }





    public static class GlobalVars
    {

        public static int Timer_count { get; set; } = 0;
        public static void SetTimerCount() => Timer_count++;

        public static void ResetTimerCount() => Timer_count = 0;

        const string filePath = (@"Resources\HighScore.json");
        public static HighScore_Total_Frogger highScore_Total { get; set; }

        public static void AddHighScore(int difficalty, int score)
        {
            var highScore_Player = new HighScore_Player();
            highScore_Player.time_complete = score;
            var number_of_field = 1;
            var title = "Insert Name for high score";
            var Input_field = new Common_Classes.Input_box_field();
            Input_field.Input_label = "Enter name:";
            var input_Box = new Input_box(number_of_field, title, Input_field);
            input_Box.ShowDialog();
            highScore_Player.player_Name = UniversalVars.inputBoxReturn[0].ToString();

            switch (difficalty)
            {
                case 1:
                    highScore_Total.Difficalty_1.AddPlayer(highScore_Player);
                    break;
                case 2:
                    highScore_Total.Difficalty_2.AddPlayer(highScore_Player);
                    break;
                case 3:
                    highScore_Total.Difficalty_3.AddPlayer(highScore_Player);
                    break;
                case 4:
                    highScore_Total.Difficalty_4.AddPlayer(highScore_Player);
                    break;
                case 5:
                    highScore_Total.Difficalty_5.AddPlayer(highScore_Player);
                    break;
                case 6:
                    highScore_Total.Difficalty_6.AddPlayer(highScore_Player);
                    break;
                case 7:
                    highScore_Total.Difficalty_7.AddPlayer(highScore_Player);
                    break;
                default:
                    break;
            }
        }

        public static void LoadHighscores()
        {
            if (!File.Exists(filePath))
            {
                HighScore_Total_Frogger NewHighScored = new HighScore_Total_Frogger();
                highScore_Total = NewHighScored;
                SaveHighscores();
                return;
            }

            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<HighScore_Total_Frogger>(rawData);
                

                if (result == null)
                {
                    HighScore_Total_Frogger NewHighScored = new HighScore_Total_Frogger();
                    highScore_Total = NewHighScored;
                    return;
                }
                highScore_Total = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }

        public static void SaveHighscores()
        {
            var export = JsonSerializer.Serialize(highScore_Total);
            try
            {
                File.WriteAllText(filePath, export);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadHighscores();
        }
    }

    public class scoreKeeping
    {
        public int Difficalty;
        public int Lives = 5;
        public int Wins = 0;

        public void initialze()
        {
            Lives = 5;
            Wins = 0;
        }

    }


}
