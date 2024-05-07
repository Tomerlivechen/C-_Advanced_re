using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TickTackTow_WPF;

class WPF_adaptation
{



    public class GameEventArgs : EventArgs
    {
        public int player;
    }

    public static void makemove(Gameboard gameboard,int position)
    {
        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                counter++;
                if (counter == position && gameboard.positions[i, j] == 0)
                {
                    gameboard.positions[i, j] = gameboard.player;
                    return;
                }
            }
        }



    }


}

public class Player
{
    public int _id;
    public int wins = 0;
    public int draws = 0;

    public Player(int id)
    {
        _id = id;
    }

    public void Playerwins()
    {
        wins++;
    }
    public void PlayerdRAWS()
    {
        draws++;
    }

}

public class CompPlayer : Player
{
    public CompPlayer(int id) : base(id)
    {
    }
}
