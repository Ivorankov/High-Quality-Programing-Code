namespace Cooking
{
    using System;
    using System.Collections.Generic;

    public class Bowl : Vegetable
    {
        public Bowl()
        {
            this.Vegetables = new List<Vegetable>();
        }

        public List<Vegetable> Vegetables { get; private set; }

        public void Add(Vegetable vegetable)
        {
            this.Vegetables.Add(vegetable);
        }
    }
}
