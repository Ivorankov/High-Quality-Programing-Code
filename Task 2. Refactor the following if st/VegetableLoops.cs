namespace Task_2
{
    using System;
    using Cooking;

    public class VegetableLoops
    {
        internal static void Main()
        {
            Potato goodPotato = new Potato();
            Potato badPotato = new Potato();
            Carrot carrot = new Carrot();
            Chef gRamsay = new Chef("G - Ramsay");

            gRamsay.PrepareVegetable(goodPotato);
            gRamsay.PrepareVegetable(carrot);

            Console.WriteLine("Test 1: (press any key for test 2)");
            CookMeal(gRamsay, goodPotato, carrot);

            Console.WriteLine("Test 2:");
            CookMeal(gRamsay, badPotato, carrot);
        }

        internal static void CookMeal(Chef chef, Potato potato, Carrot carrot)
        {
            if (potato != null && chef != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    chef.Cook(potato, carrot);
                }
                else
                {
                    Console.WriteLine(chef.Name + " ANGRY!!! " + chef.Name + " SMASHHH!!!");
                    Console.WriteLine("Don't you be givin me no rotten potatoes!");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Where my potato AT!");
            }
        }
    }
}
