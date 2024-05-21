using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Speed_Racer.Resources.Classes
{
    public class High_score_player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public High_score_player(string _Name, int _Score)
        {
            Name = _Name;
            Score = _Score;
        }
    }
}
