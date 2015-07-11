namespace Cooking
{
    using System;
    using System.Collections.Generic;

    public class Chef
    {
        public Chef(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Cook(Potato potato, Carrot carrot)
        {
            if (potato == null)
            {
                throw new ArgumentException("ArugumentOutOfPotatoExeption");
            }

            if (carrot == null)
            {
                throw new ArgumentException("ArugumentOutOfCarrotExeption");
            }

            var bowl = this.GetBowl();

            bowl.Add(carrot);
            bowl.Add(potato);

            Console.WriteLine("Your meal contains: ");
            foreach (var vegetable in bowl.Vegetables)
            {
                Console.WriteLine(vegetable);
            }

            Console.ReadKey();
        }

        public void PrepareVegetable(Vegetable vegerable)
        {
            this.Peel(vegerable);
            this.Cut(vegerable);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine("Chop* Chop*");
        }

        private void Peel(Vegetable vegetable)
        {
            Console.WriteLine("Slice* Slice*");
            vegetable.IsPeeled = true;
        }
    }
}
