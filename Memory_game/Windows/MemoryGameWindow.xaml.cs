using Common_Classes;
using Memory_game.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;
using Memory_game.Classes;
using Common_Classes.Classes;
namespace Memory_game
{
    /// <summary>
    /// Interaction logic for MemoryGameWindow.xaml
    /// </summary>
    public partial class MemoryGameWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        public MemoryGameWindow(int card_amount)
        {
            InitializeComponent();
           int[] screenSize= Initialization_Of_Game.screen_size(card_amount);
            this.Height = screenSize[0];
            this.Width = screenSize[1];
            if (card_amount == 48)
            {
                this.WindowState = WindowState.Maximized;
            }
            List<Memory_Card> GameCards = Initialization_Of_Game.Setgame(card_amount);
            Initializeboard();
            GlobalVars.ResetTimerCount();
            Closed += Window_Closed;
            BG_Image.Source = Initialization_Of_Game.LoadImageFromResource("BG_Image.jpg");
            
            void Initializeboard()
            {
                foreach (Memory_Card card in GameCards)
                {
                    Card M_card = new Card(card)
                    {
                        Margin = new Thickness(3),
                        Height = 225,
                        Width = 150,
                    };
                    Card_set.Children.Add(M_card);
                }
            }
            void Timed_Actions(object sender, EventArgs e)
            {
                int freeCards = 0;
                GlobalVars.SetTimerCount();
                Time_keeper.Text = GlobalVars.Timer_count.ToString();
                foreach (Memory_Card card in GameCards)
                {
                    if (card.Viable)
                    {
                        freeCards++;
                    }
                }
                if (freeCards == 0)
                {
                    GlobalVars.AddHighScore(card_amount, GlobalVars.Timer_count);
                    int respons = Message_Box_Classes.DisplayMessageBox($"Game compleated in {GlobalVars.Timer_count} seconds\n Play again?", "Congratulations");
                    if (respons == 1)
                    {
                        GameCards = Initialization_Of_Game.Setgame(card_amount);
                        Card_set.Children.Clear();
                        Initializeboard();
                        GlobalVars.ResetTimerCount();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            timer.Tick += Timed_Actions;
            timer.Start();
            void Window_Closed(object sender, EventArgs e)
            {
                timer.Stop();
            }
        }
    }
}