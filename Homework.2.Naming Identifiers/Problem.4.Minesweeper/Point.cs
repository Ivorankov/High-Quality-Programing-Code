namespace Mines
{
    using System;

    public class Player
    {
        string name;
        int points;

        public string Name
        {
            get
            {
                return name; 
            }
            set 
            {
                name = value;
            }
        }

        public int Points
        {
            get 
            {
                return points;
            }
            set 
            {
                points = value;
            }
        }

        public Player() { }

        public Player(string name, int points)
            :this()
        {
            this.name = name;
            this.points = points;
        }
    }
}
