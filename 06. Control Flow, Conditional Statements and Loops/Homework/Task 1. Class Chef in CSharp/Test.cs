namespace Cooking
{
    using System;

    public class Test
    {
        static void Main()
        {
            Chef test = new Chef("Some Guy");
            Carrot carrot = new Carrot();
            Potato potato = new Potato();
            test.PrepareVegetable(carrot);
            test.PrepareVegetable(potato);
            test.Cook(potato, carrot);
        }
    }
}
