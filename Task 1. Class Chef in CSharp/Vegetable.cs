namespace Cooking
{
    using System;

    public class Vegetable
    {
        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsRotten = false;
        }
        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }

    }
}
