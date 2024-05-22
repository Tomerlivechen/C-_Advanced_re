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
