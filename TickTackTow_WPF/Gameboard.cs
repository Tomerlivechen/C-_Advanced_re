using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TickTackTow_WPF
{
    public class Gameboard
    {
        public int[,] positions = new int[3, 3]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

        public int player = 1;
        public int tempPlayer;

        Random rand = new Random();

        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    positions[i, j] = 0;
                }
            }
            player = 1;
        }

        public bool MakeMove(string playername = null)
        {
            int space;
            bool moved = false;
            bool winCase = false;
            bool fullboard = false;

            if (!string.IsNullOrEmpty(playername))
            {
                do
                {
                    string makemove = "Choose a square to mark\n╔═══╦═══╦═══╗\n║ 1 ║ 2 ║ 3 ║\n╠═══╬═══╬═══╣\n║ 4 ║ 5 ║ 6 ║\n╠═══╬═══╬═══╣\n║ 7 ║ 8 ║ 9 ║\n╚═══╩═══╩═══╝";
                    space = FoolProofing.RequestANumber(makemove, 1, 9);
                    moved = IsValidMove(space, player);
                    if (moved)
                    {
                        Console.WriteLine($"Player {player} has made a move");
                    }
                    else if (!moved)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Space is occupied");
                        Console.ResetColor();
                    }
                } while (!moved);
            }
            else
            {
                do
                {

                    //  space = (int)rand.Next(1, 10);
                    space = Smart_Move.MakeSmarMove(positions, player);
                    moved = IsValidMove(space, player);
                    if (moved)
                    {
                        Console.WriteLine($"Computer {player} has made a move");
                    }
                    else if (!moved)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Space is occupied");
                        Console.ResetColor();
                    }
                } while (!moved);
            }

            tempPlayer = player;
            switchplayer();
            DisplayBoard();
            winCase = CheckWin(string.IsNullOrEmpty(playername) ? $"Computer {tempPlayer}" : playername);
            fullboard = IsBoardFull();

            if (winCase)
            {
                ResetBoard();
                return true;
            }
            if (fullboard)
            {
                ResetBoard();
                return false;
            }

            return false;
        }


        public bool IsValidMove(int space, int player)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    counter++;
                    if (counter == space && positions[i, j] == 0)
                    {
                        positions[i, j] = player;
                        return true;
                    }
                    if (counter == space && positions[i, j] > 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }


        void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════╗");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("║");
                for (int j = 0; j < 3; j++)
                {
                    if (positions[i, j] == 0)
                    {
                        Console.Write("   ");
                    }
                    if (positions[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" X ");
                        Console.ResetColor();
                    }
                    if (positions[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" O ");
                        Console.ResetColor();
                    }
                    Console.Write("║");
                }
                Console.WriteLine();
                if (i != 2)
                {
                    Console.WriteLine("║───┼───┼───║");
                }
            }
            Console.WriteLine("╚═══════════╝");
        }


        public bool CheckWin(string playername = "")
        {
            for (int i = 0; i < 3; i++)
            {
                if (positions[i, 0] == positions[i, 1] && positions[i, 1] == positions[i, 2] && positions[i, 2] > 0)
                {
                    winPrompt(positions[i, 0], playername);
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (positions[0, i] == positions[1, i] && positions[1, i] == positions[2, i] && positions[2, i] > 0)
                {
                    winPrompt(positions[0, i], playername);
                    return true;
                }
            }

            if (positions[0, 0] == positions[1, 1] && positions[1, 1] == positions[2, 2] && positions[2, 2] > 0)
            {
                winPrompt(positions[0, 0], playername);
                return true;
            }
            if (positions[0, 2] == positions[1, 1] && positions[1, 1] == positions[2, 0] && positions[2, 0] > 0)
            {
                winPrompt(positions[0, 2], playername);
                return true;
            }
            return false;
        }

        public bool IsBoardFull()
        {
            int counter = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (positions[i, j] > 0)
                    {
                        counter++;
                    };
                }
            }

            if (counter == 9)
            {
                return true;
            }
            else
            {
                return false;
            }


        }





        void winPrompt(int player, string playername = "")
        {
            FoolProofing.Devider(1);
            if (playername != "")
            {
                Console.WriteLine($"Player {playername} Wins");
            }
            else
            {
                Console.WriteLine($"Player {(player == 1 ? 'X' : 'O')} Wins");
            }
            FoolProofing.Devider(0);
        }

        public void switchplayer()
        {
            if (player == 1)
            {
                player = 2;
            }
            else
            {
                player = 1;
            }
        }


    }
}

