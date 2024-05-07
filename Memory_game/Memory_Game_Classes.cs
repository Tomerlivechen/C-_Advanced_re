using Common_Classes;
using Common_Classes.Common_Elements;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Memory_game;

class Memory_Game_Classes { }

public class Memory_Card : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public Memory_Card() => VisibleImage = Back;

    BitmapImage _visibleImage;
    public BitmapImage VisibleImage
    {
        get { return _visibleImage; }
        set
        {
            _visibleImage = value;
            OnPropertyChanged(nameof(VisibleImage));
        }
    }

    void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int Posotion { get; set; }
    public string Pic { get; set; }

    public void setPic(string value) => Pic = value;

    public BitmapImage Image => Initialization_Of_Game.LoadImageFromResource($"CardImage{Pic}.png");

    public static BitmapImage Back => Initialization_Of_Game.LoadImageFromResource("CardImageBack.png");

    public bool Face { get; set; } = false;
    public bool Viable { get; set; } = true;

    public void InternalDeflip()
    {
        if (!Viable)
        {
            Face = true;
            return;
        }

        if (Viable)
        {
            Face = !Face;

            if (Face)
            {
                VisibleImage = Image;
            }
            else
            {
                VisibleImage = Back;
            }
        }
    }

    public void Flip(object sender, RoutedEventArgs e)
    {
        Initialization_Of_Game.Checkstatus(this);
        InternalDeflip();
    }
}

public static class GlobalVars
{
    public static Memory_Card first_Card { get; set; } = null;

    public static void SetFirstCard(Memory_Card value) => first_Card = value;

    public static Memory_Card second_Card { get; set; } = null;

    public static void SetSecondCard(Memory_Card value) => second_Card = value;

    public static int Timer_count { get; set; } = 0;
    public static void SetTimerCount() => Timer_count++;

    public static void ResetTimerCount() => Timer_count = 0;

    const string filePath = (@"Resources\HighScore.json");
    public static HighScore_Total highScore_Total { get; set; }

    public static void AddHighScore(int cardNum, int score)
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

        switch (cardNum)
        {
            case 12:
                highScore_Total.High_Score_12.AddPlayer(highScore_Player);
                break;
            case 18:
                highScore_Total.High_Score_18.AddPlayer(highScore_Player);
                break;
            case 24:
                highScore_Total.High_Score_24.AddPlayer(highScore_Player);
                break;
            case 30:
                highScore_Total.High_Score_30.AddPlayer(highScore_Player);
                break;
            case 36:
                highScore_Total.High_Score_36.AddPlayer(highScore_Player);
                break;
            case 48:
                highScore_Total.High_Score_48.AddPlayer(highScore_Player);
                break;
            default:
                break;
        }
    }

    public static void LoadHighscores()
    {
        if (!File.Exists(filePath))
        {
            HighScore_Total NewHighScored = new HighScore_Total();
            highScore_Total = NewHighScored;
            SaveHighscores();
            return;
        }

        try
        {
            var rawData = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<HighScore_Total>(rawData);
            

            if (result == null)
            {
                HighScore_Total NewHighScored = new HighScore_Total();
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

public static class Initialization_Of_Game
    {
        public static int[] screen_size(int card_amount)
        {
            switch (card_amount)
            {
                case 12:
                    return [850, 800];
                    break;
                case 18:
                    return [850, 1000];
                    break;
                case 24:
                    return [850, 1300];
                    break;
                case 30:
                    return [850, 1600];
                    break;
                case 36:
                    return [800, 1915];
                    break;
                case 48:
                    return [1055, 1900];
                    break;
                default:
                    return [0, 0];
                    break;
            }
        }

        public static void Checkstatus(Memory_Card flippedCard)
        {
            if (GlobalVars.first_Card != null && GlobalVars.second_Card != null)
            {
                GlobalVars.first_Card.InternalDeflip();
                GlobalVars.second_Card.InternalDeflip();
                GlobalVars.SetFirstCard(null);
                GlobalVars.SetSecondCard(null);
                GlobalVars.SetFirstCard(flippedCard);
                return;
            }

            if (GlobalVars.first_Card != null && GlobalVars.first_Card.Pic == flippedCard.Pic)
            {
                GlobalVars.first_Card.Viable = false;
                flippedCard.InternalDeflip();
                flippedCard.Viable = false;
                GlobalVars.SetFirstCard(null);
                GlobalVars.SetSecondCard(null);
                return;
            }

            if (GlobalVars.first_Card == null)
            {
                GlobalVars.SetFirstCard(flippedCard);
                return;
            }

            if (GlobalVars.second_Card == null)
            {
                GlobalVars.SetSecondCard(flippedCard);
                return;
            }
        }

        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/{resourceName}"
            );

            return new BitmapImage(uri);
        }

        public static List<Memory_Card> Setgame(int Amount)
        {
            var cards = new List<Memory_Card>();

            for (int i = 0; i < Amount; i++)
                cards.Add(new Memory_Card());


            cards = CastCards(cards);
            return cards;
        }

        public static List<Memory_Card> CastCards(List<Memory_Card> cards)
        {
            var positionArray = new int[cards.Count];
            var picArray = new int[cards.Count];
            var rand = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                positionArray[i] = i;

                if (i < cards.Count / 2)
                {
                    picArray[i] = i;
                    picArray[cards.Count - i - 1] = i;
                }
            }

            rand.Shuffle(positionArray);
            rand.Shuffle(picArray);
            var index = -1;

            foreach (Memory_Card card in cards)
            {
                index++;
                card.Posotion = positionArray[index];
                card.setPic(picArray[index].ToString());
            }

            return cards;
        }
    }