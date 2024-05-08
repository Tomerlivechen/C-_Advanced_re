using System.Numerics;
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
using System.Windows.Threading;
using Taki_Game.Resources.Controls;

namespace Taki_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        public int setPlayer;
        bool buttonClickChange = false;
        bool buttonClickChangeCheck = false;
        public MainWindow(int players)
        {
            InitializeComponent();

            GlobalVars.setNumOfPlayers(players);
            Game.StartGame(players);
            timer1.Start();
            timer1.Tick += visualUpdates;
        }

        private void visualUpdates(object? sender, EventArgs e)
        {
            Game.checkWin(GlobalVars.NumOfPlayers);
            ClosingTaki();
            updatePlayer();
            updateStackSet();

        }
        public void updatePlayer()
        {
            player_num.Content = $"Player {GlobalVars.player.ToString()}:";

                setPlayer = GlobalVars.player;

                switch (GlobalVars.player)
                {
                    case 1:
                        UpdateCardSet(Game.player1);
                    player_num.Content += Game.player1.name;
                        break;
                    case 2:
                        UpdateCardSet(Game.player2);
                    player_num.Content += Game.player2.name;
                    break;
                    case 3:
                        UpdateCardSet(Game.player3);
                    player_num.Content += Game.player3.name;
                    break;
                    case 4:
                        UpdateCardSet(Game.player4);
                    player_num.Content += Game.player4.name;
                    break;
                    default: break;
                }
            
        }


        public void updateStackSet()
        {
            card_stack.Children.Clear();
            Taki_Card T_card = new Taki_Card(GlobalVars.lastCardInStack)
            {
                Margin = new Thickness(3),
                Height = 250,
                Width = 180,
            };
            card_stack.Children.Add(T_card);
        }
        public void ClosingTaki()
        {
                        if (GlobalVars.TakiActive == true)
            {
                Close_Taki.Visibility = Visibility.Visible;
                End_turn.Visibility = Visibility.Visible;
            }
            if(GlobalVars.TakiActive == false)
            {
                Close_Taki.Visibility = Visibility.Collapsed;
                End_turn.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateCardSet(Player_class player)
        {

                player_wrap.Children.Clear();
                foreach (TakiCard card in player.DeckInHand)
                {

                    Taki_Card T_card = new Taki_Card(card)
                    {
                        Margin = new Thickness(3),
                        Height = 125,
                        Width = 90,
                    };
                    player_wrap.Children.Add(T_card);

                }

        }



        private void Deck_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVars.TakiActive)
            {
                MessageBox.Show("Impossible move", "Impossible move");
                return;
            }
            if (GlobalVars.Plus2Active == true)
            {
                GlobalVars.Plus2Active = false;
                switch (GlobalVars.player)
                {
                    case 1:
                        Game.PeneltyDraw(Game.player1);
                        break;
                    case 2:
                        Game.PeneltyDraw(Game.player2);
                        break;
                    case 3:
                        Game.PeneltyDraw(Game.player3);
                        break;
                    case 4:
                        Game.PeneltyDraw(Game.player4);
                        break;
                    default: break;
                }
            }
            switch (GlobalVars.player)
            {
                case 1:
                    Game.DrawCard(Game.player1, true);
                    break;
                case 2:
                    Game.DrawCard(Game.player2, true);
                    break;
                case 3:
                    Game.DrawCard(Game.player3, true);
                    break;
                case 4:
                    Game.DrawCard(Game.player4, true);
                    break;
                    default: break;
            }
        }

        private void Close_Taki_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.closeTaki();
            GlobalVars.nextPlayer();
        }

        private void Close_End_turn(object sender, RoutedEventArgs e)
        {
            GlobalVars.nextPlayer();
        }
    }
}