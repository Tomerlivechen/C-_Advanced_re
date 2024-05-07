using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Reflection;
using Taki_Game.Resources.Controls;
using System.Numerics;
using System.Collections;
using System.Windows.Controls;
using Common_Classes;
using Common_Classes.Common_Elements;
using static System.Formats.Asn1.AsnWriter;

namespace Taki_Game
{
    class Taki_Game_Classes
    {
    }
    public class TakiCard : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TakiCard() => VisibleImage = Back;

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

        public string color { get; set; }
        public string val { get; set; }
        public string Pic { get; set; }

        
        public void setSetColor(string value) => color = value;
        public void setSetValue(string value) => val = value;
        public void setPic() => Pic = $"{color}{val}";

        public void ResetCard()
        {
            Decak = true;
            Stack = false;
            Player = 0;
            Hand = false;
            notStack = true;
        }
        public void GiveCard(int player)
        {
            Decak = true;
            Stack = false;
            Player = player;
            Hand = true;
            notStack = true;
        }


        public BitmapImage Image => GlobalVars.LoadImageFromResource($"{Pic}.png");

        public static BitmapImage Back => GlobalVars.LoadImageFromResource("CardImageBack.png");

        public bool Decak { get; set; } = false;
        public bool Stack { get; set; } = false;
        public bool Hand { get; set; } = false;

        public bool notStack { get; set; } = false;

        public int Player { get; set; }

        public void Internalflip(int player)
        {
            if (Hand)
            {
                if (Player == player)
                {
                    VisibleImage = Image;
                    return;
                }
                else
                {
                    VisibleImage = Back;
                    return;
                }
            }
        }
        public void InternalDeflip()
        {
            if (notStack)
            {

                VisibleImage = Back;
                return;
            }

        }

        public void PlayCard()
        {
            if (GlobalVars.TakiActive)
            {
                if (this.color == GlobalVars.TakiColor)
                {
                    GlobalVars.nextCardOutStack(this);
                    if (this.val == "2+")
                    {
                        MessageBox.Show("Impossible move", "Impossible move");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Impossible move", "Impossible move");
                }
            }
            if (!GlobalVars.TakiActive)
            {
                if (this.val == GlobalVars.lastCardInStack.val || this.color == GlobalVars.lastCardInStack.color || this.color == "" || GlobalVars.lastCardInStack.val == "Change")
                {
                    GlobalVars.nextCardOutStack(this);
                }
                else
                {
                    MessageBox.Show("Impossible move", "Impossible move");
                }
            }
            
        }


    }

    public class Player_class
    {
        public int index { get; set; }
        public string name { get; set; } 

        public List<TakiCard> DeckInHand = new List<TakiCard>();

        public int Wins { get; set; } = 0;

    }

    public static class Game
    {
        public static void checkWin(int players)
        {
            if (players == 2)
            {
                if (player1.DeckInHand.Count == 0)
                {
                    playerWin(player1);
                }
                if (player2.DeckInHand.Count == 0)
                {
                    playerWin(player2);
                }
            }
            if (players == 3)
            {
                if (player1.DeckInHand.Count == 0)
                {
                    playerWin(player1);
                }
                if (player2.DeckInHand.Count == 0)
                {
                    playerWin(player2);
                }
                if (player3.DeckInHand.Count == 0)
                {
                    playerWin(player4);
                }
            }
            if (players == 4)
            {
                
                if (player1.DeckInHand.Count == 0)
                {
                    playerWin(player1);

                }
                if (player2.DeckInHand.Count == 0)
                {
                    playerWin(player2);

                }
                if (player3.DeckInHand.Count == 0)
                {
                    playerWin(player3);

                }
                if (player4.DeckInHand.Count == 0)
                {
                    playerWin(player4);

                }
            }

        }
        public static void playerWin(Player_class player)
        {
            if (GlobalVars.Win == false)
            {
                GlobalVars.Win = true;
                MessageBox.Show($"{player.name} Wins", "Winner");
                int respose = Message_Box_Classes.DisplayMessageBox("Would you like to play again", "Player Again");
                if (respose == 1)
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Name != "Index_Window" || window.Name != "GameWindow")
                        {
                            GlobalVars.InitilizeAllParameters();
                            StartGame(GlobalVars.NumOfPlayers);
                            window.Close();
                        }
                    }

                    StartGame(GlobalVars.NumOfPlayers);
                }
                else
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.Name != "Index_Window")
                        {
                            GlobalVars.InitilizeAllParameters();
                            StartGame(0, false);
                            window.Close();
                        }
                    }
                }
            }
        }
        public static Player_class player1 { get; set; } = new Player_class();
        public static Player_class player2 { get; set; } = new Player_class();
        public static Player_class player3 { get; set; } = new Player_class();
        public static Player_class player4 { get; set; } = new Player_class();

        public static void SetPlayerName(Player_class player, bool initilize)
        {
            if (initilize)
            {
                var number_of_field = 1;
                var title = $"Insert Name of player {player.index}";
                var Input_field = new Common_Classes.Input_box_field();
                Input_field.Input_label = "Enter name:";
                var input_Box = new Input_box(number_of_field, title, Input_field);
                input_Box.ShowDialog();
                player.name = UniversalVars.inputBoxReturn[0].ToString();
            }
        }

        public static void StartGame(int players , bool initilaize=true)
        {
            GlobalVars.Win = false;
            GlobalVars.setDeck();
            if (players == 0)
            {
                player1.index = 1;
                player2.index = 2;
                player3.index = 3;
                player4.index = 4;
                player1.DeckInHand = new List<TakiCard>();
                player2.DeckInHand = new List<TakiCard>();
                player3.DeckInHand = new List<TakiCard>();
                player4.DeckInHand = new List<TakiCard>();
                GetCards(player1);
                GetCards(player2);
                GetCards(player3);
                GetCards(player4);
            }

            if (players == 2)
            {
                player1.index = 1;
                player2.index = 2;
                SetPlayerName(player1, initilaize);
                SetPlayerName(player2, initilaize);
                player1.DeckInHand = new List<TakiCard>();
                player2.DeckInHand = new List<TakiCard>();
                GetCards(player1);
                GetCards(player2);
            }
            if (players == 3)
            {
                player1.index = 1;
                player2.index = 2;
                player3.index = 3;
                SetPlayerName(player1, initilaize);
                SetPlayerName(player2, initilaize);
                SetPlayerName(player3, initilaize);
                player1.DeckInHand = new List<TakiCard>();
                player2.DeckInHand = new List<TakiCard>();
                player3.DeckInHand = new List<TakiCard>();
                GetCards(player1);
                GetCards(player2);
                GetCards(player3);
            }
            if (players == 4)
            {
                player1.index = 1;
                player2.index = 2;
                player3.index = 3;
                player4.index = 4;
                SetPlayerName(player1, initilaize);
                SetPlayerName(player2, initilaize);
                SetPlayerName(player3, initilaize);
                SetPlayerName(player4, initilaize);
                player1.DeckInHand = new List<TakiCard>();
                player2.DeckInHand = new List<TakiCard>();
                player3.DeckInHand = new List<TakiCard>();
                player4.DeckInHand = new List<TakiCard>();
                GetCards(player1);
                GetCards(player2);
                GetCards(player3);
                GetCards(player4);
            }
            GlobalVars.nextCardOutStack(GlobalVars.activeDeck[0]);
            GlobalVars.activeDeck.Remove(GlobalVars.activeDeck[0]);
            GlobalVars.closeTaki();
        }

        public static void GetCards(Player_class player)
        {
            for (int i = 0; i < 8; i++)
            {
                DrawCard(player);
            }
            
        }

        public static void DrawCard(Player_class player, bool inTurn=false)
        {

            if (GlobalVars.activeDeck.Count <= 1)
            {
                reShuffleStack();
            }
                GlobalVars.activeDeck[0].GiveCard(player.index);
                player.DeckInHand.Add(GlobalVars.activeDeck[0]);
                GlobalVars.activeDeck.Remove(GlobalVars.activeDeck[0]);
            if (inTurn)
            {
                GlobalVars.nextPlayer();
            }

        }

        public static void PeneltyDraw(Player_class player)
        {
            if (GlobalVars.activeDeck.Count > GlobalVars.Plus2Accumulation)
            {
                for (int i = 0; i < GlobalVars.Plus2Accumulation; i++)
                {
                    DrawCard(player);
                }
            }
            else
            {
                reShuffleStack();
                for (int i = 0; i < GlobalVars.Plus2Accumulation; i++)
                {
                    DrawCard(player);
                }

            }
            GlobalVars.Plus2Accumulation = 0;
        }

        public static void reShuffleStack()
        {
            GlobalVars.setDeck();
            foreach (TakiCard takiCard in player1.DeckInHand)
            {
                RemoveCardFromDeck(takiCard);
            }
            foreach (TakiCard takiCard in player2.DeckInHand)
            {
                RemoveCardFromDeck(takiCard);
            }
            foreach (TakiCard takiCard in player3.DeckInHand)
            {
                RemoveCardFromDeck(takiCard);
            }
            foreach (TakiCard takiCard in player4.DeckInHand)
            {
                RemoveCardFromDeck(takiCard);
            }
            RemoveCardFromDeck(GlobalVars.lastCardInStack);

        }

        public static void RemoveCardFromDeck(TakiCard takiCard)
        {
            TakiCard cardToRemove = GlobalVars.activeDeck.Find(card => card.Pic == takiCard.Pic);
            if (cardToRemove != null)
            {
                GlobalVars.activeDeck.Remove(cardToRemove);
            }
        }
    }

    public static class GlobalVars
    {
        public static List<TakiCard> wholeDeck = new List<TakiCard>();
        public static List<TakiCard> activeDeck = new List<TakiCard>();

        public static void setDeck()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (string color in card_colors)
                {
                    foreach (string type in General_card_types)
                    {
                        TakiCard takiCard = new TakiCard();
                        takiCard.ResetCard();
                        takiCard.color = color;
                        takiCard.val = type;
                        takiCard.setPic();
                        wholeDeck.Add(takiCard);
                    }
                }
            }
            foreach (string type in Special_card_types)
            {
                TakiCard takiCard = new TakiCard();
                takiCard.ResetCard();
                takiCard.color = "";
                takiCard.val = type;
                takiCard.setPic();
                wholeDeck.Add(takiCard);
            }
             Random rand = new Random();

            //          rand.Shuffle(wholeDeck.ToArray());
            wholeDeck.Shuffle();
            activeDeck = wholeDeck;

        }
        // copied from stack overflow becuase internal rand.Shuffle didn't work with a list only with an array
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random(); 
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/Images/{resourceName}"
            );

            return new BitmapImage(uri);
        }

        public static List<string> General_card_types
        {
            get
            {
                List<string> types = new List<string>()
                {
                    "1","2+","3","4","5","6","7","8","9","COrder","Plus","Stop","Taki",
                };

                return types;
            }
        }
        public static List<string> Special_card_types
        {
            get
            {
                List<string> types = new List<string>()
                {
                    "Change","Color","Taki",
                };
                return types;
            }
        }
        public static List<string> card_colors
        {
            get
            {
                List<string> types = new List<string>()
                {
                    "Y_","B_","G_","R_"
                };
                return types;
            }
        }


        public static void removeCardfromPlayer(TakiCard cardToRemove)
        {
            switch (GlobalVars.player)
            {
                case 1:
                    Game.player1.DeckInHand.Remove(cardToRemove);
                    break;
                case 2:
                    Game.player2.DeckInHand.Remove(cardToRemove);
                    break;
                case 3:
                    Game.player3.DeckInHand.Remove(cardToRemove);
                    break;
                case 4:
                    Game.player4.DeckInHand.Remove(cardToRemove);
                    break;
                default: break;
            }
        }

        public static TakiCard lastCardInStack;

        public static void nextCardOutStack(TakiCard nextcard)
        {
            lastCardInStack = nextcard;
            lastCardInStack.Decak = false;
            lastCardInStack.Stack = true;
            lastCardInStack.Hand = false;
            lastCardInStack.notStack = false;
            lastCardInStack.VisibleImage = lastCardInStack.Image;
            lastCardInStack.Player = 0;
            removeCardfromPlayer(nextcard);
            if (lastCardInStack.val == "Taki")
            {
                TakiActive = true;
                if (lastCardInStack.color != "")
                {
                    TakiColor = lastCardInStack.color;
                }
                else
                {
                    askColor();
                    lastCardInStack.color = TakiColor;
                }
            }
            if (lastCardInStack.val == "Color")
            {
                    askColor();
                lastCardInStack.color = TakiColor;
            }
            if (lastCardInStack.val == "Change")
            {
                if (NumOfPlayers == 2)
                {
                    List<TakiCard> templist1 = new List<TakiCard>();
                    List<TakiCard> templist2 = new List<TakiCard>();

                    templist1 = Game.player1.DeckInHand;
                    templist2 = Game.player2.DeckInHand;

                    foreach (TakiCard card in templist1)
                    {
                        card.Player = 2;
                    }
                    foreach (TakiCard card in templist2)
                    {
                        card.Player = 1;
                    }
                    Game.player1.DeckInHand = templist2;
                    Game.player2.DeckInHand = templist1;
                }
                if (NumOfPlayers == 3)
                {
                    List<TakiCard> templist1 = new List<TakiCard>();
                    List<TakiCard> templist2 = new List<TakiCard>();
                    List<TakiCard> templist3 = new List<TakiCard>();
                   
                    templist1 = Game.player1.DeckInHand;
                    templist2 = Game.player2.DeckInHand;
                    templist3 = Game.player3.DeckInHand;
                   

                    foreach (TakiCard card in templist1)
                    {
                        card.Player = 3;
                    }
                    foreach (TakiCard card in templist2)
                    {
                        card.Player = 2;
                    }
                    foreach (TakiCard card in templist3)
                    {
                        card.Player = 1;
                    }
                    Game.player1.DeckInHand = templist3;
                    Game.player2.DeckInHand = templist2;
                    Game.player3.DeckInHand = templist1;
                }
                if (NumOfPlayers == 4)
                {
                    List<TakiCard> templist1 = new List<TakiCard>();
                    List<TakiCard> templist2 = new List<TakiCard>();
                    List<TakiCard> templist3 = new List<TakiCard>();
                    List<TakiCard> templist4 = new List<TakiCard>();
                    templist1 = Game.player1.DeckInHand;
                    templist2 = Game.player2.DeckInHand;
                    templist3 = Game.player3.DeckInHand;
                    templist4 = Game.player4.DeckInHand;

                    foreach (TakiCard card in templist1)
                    {
                        card.Player = 4;
                    }
                    foreach (TakiCard card in templist2)
                    {
                        card.Player = 3;
                    }
                    foreach (TakiCard card in templist3)
                    {
                        card.Player = 2;
                    }
                    foreach (TakiCard card in templist4)
                    {
                        card.Player = 1;
                    }
                    Game.player1.DeckInHand = templist4;
                    Game.player2.DeckInHand = templist3;
                    Game.player3.DeckInHand = templist2;
                    Game.player4.DeckInHand = templist1;
                }
            }
            if (lastCardInStack.val == "COrder")
            {
                revers = !revers;
            }

            if (lastCardInStack.val == "2+")
            {
                if (Plus2Active)
                {
                    Plus2();
                }
                if (!Plus2Active)
                {
                    Plus2Active = true;
                    Plus2();
                }
            }
            if (Plus2Active && lastCardInStack.val != "2+")
            {
                Plus2Active = false;

                switch (player)
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
                    default:
                        break;
                }
            }
            if (lastCardInStack.val == "Plus" || TakiActive == true)
            {
                return;
            }
            if (lastCardInStack.val == "Stop" )
            {
                nextPlayer(true);
                return;
            }
            if (lastCardInStack.val != "Plus" || TakiActive == false)
            {
                nextPlayer();
                return;
            }

        }

        public static void askColor()
        {
            SelectColor selectColor = new SelectColor();
            selectColor.ShowDialog();
        }
    
        public static void InitilizeAllParameters()
        {
            revers = false;
            TakiActive = false;
            Plus2Active = false;
            Plus2Accumulation = 0;
            Win = false;
            setNumOfPlayers(0);
            setDeck();
        }
        public static bool revers { get; set; } = false;
        public static bool TakiActive { get; set; } = true;
        public static string TakiColor { get; set; }
        public static bool Plus2Active { get; set; } = false;
        public static int Plus2Accumulation { get; set; }

        public static void playerTurnMessage()
        {
            switch (GlobalVars.player)
            {
                case 1:
                    MessageBox.Show($"{Game.player1.name}'s turn");
                    break;
                case 2:
                    MessageBox.Show($"{Game.player2.name}'s turn");
                    break;
                case 3:
                    MessageBox.Show($"{Game.player3.name}'s turn");
                    break;
                case 4:
                    MessageBox.Show($"{Game.player4.name}'s turn");
                    break;
                default: break;
            }
            
        }

        public static bool Win { get; set; } = false;

        public static int NumOfPlayers { get; set; }

        public static void setNumOfPlayers(int num)
        {
            NumOfPlayers = num;
        }
        public static void closeTaki()
        {
            TakiActive = false;
        }

        public static void Plus2()
        {
            Plus2Accumulation += 2;
        }

        public static int player = 0;

        public static void nextPlayer(bool skip = false)
        {
            if (player == 0)
            {
                player = 1;
                playerTurnMessage();
                return;
            }
            int index = 0;
            if (revers)
            {
                index = -1;
            }
            else
            {
                index = 1;
            }
            if (skip)
            {
                index = index*2;
            }
            player += index;
            if (player <= 0)
            {
                player = NumOfPlayers + player;
                playerTurnMessage();
                return;
            }
            if (player > NumOfPlayers)
            {
                player = player - NumOfPlayers;
                playerTurnMessage();
                return;
            }
            playerTurnMessage();

        }
    }

}