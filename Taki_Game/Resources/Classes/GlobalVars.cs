﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Taki_Game.Resources.Controls;

namespace Taki_Game.Resources.Classes
{
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
            if (Game.players_list.Count>0)
            {
             Game.players_list[GlobalVars.player-1].DeckInHand.Remove(cardToRemove);   
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

                    templist1 = Game.players_list[0].DeckInHand;
                    templist2 = Game.players_list[1].DeckInHand;

                    foreach (TakiCard card in templist1)
                    {
                        card.Player = 2;
                    }
                    foreach (TakiCard card in templist2)
                    {
                        card.Player = 1;
                    }
                    Game.players_list[0].DeckInHand = templist2;
                    Game.players_list[1].DeckInHand = templist1;
                }
                if (NumOfPlayers == 3)
                {
                    List<TakiCard> templist1 = new List<TakiCard>();
                    List<TakiCard> templist2 = new List<TakiCard>();
                    List<TakiCard> templist3 = new List<TakiCard>();

                    templist1 = Game.players_list[0].DeckInHand;
                    templist2 = Game.players_list[1].DeckInHand;
                    templist3 = Game.players_list[2].DeckInHand;


                    foreach (TakiCard card in templist1)
                    {
                        card.Player = 2;
                    }
                    foreach (TakiCard card in templist2)
                    {
                        card.Player = 3;
                    }
                    foreach (TakiCard card in templist3)
                    {
                        card.Player = 1;
                    }
                    Game.players_list[0].DeckInHand = templist3;
                    Game.players_list[2].DeckInHand = templist2;
                    Game.players_list[1].DeckInHand = templist1;
                }
                if (NumOfPlayers == 4)
                {
                    List<TakiCard> templist1 = new List<TakiCard>();
                    List<TakiCard> templist2 = new List<TakiCard>();
                    List<TakiCard> templist3 = new List<TakiCard>();
                    List<TakiCard> templist4 = new List<TakiCard>();
                    templist1 = Game.players_list[0].DeckInHand;
                    templist2 = Game.players_list[1].DeckInHand;
                    templist3 = Game.players_list[2].DeckInHand;
                    templist4 = Game.players_list[3].DeckInHand;

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
                    Game.players_list[0].DeckInHand = templist4;
                    Game.players_list[1].DeckInHand = templist3;
                    Game.players_list[2].DeckInHand = templist2;
                    Game.players_list[3].DeckInHand = templist1;
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

                Game.PeneltyDraw(Game.players_list[player - 1]);

            }
            if (lastCardInStack.val == "Plus" || TakiActive == true)
            {
                return;
            }
            if (lastCardInStack.val == "Stop")
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
            if (Game.players_list.Count>=2)
            {
                MessageBox.Show($"{Game.players_list[player - 1].name}'s turn");

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
                index = index * 2;
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