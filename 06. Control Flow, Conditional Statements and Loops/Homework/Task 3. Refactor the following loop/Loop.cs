namespace Task_3.Refactor_the_following_loop
{
    using System;

    class Loop
    {
        static void Main()
        {
            int[] array = new int[100];
            int expectedValue = 666;
            bool isFound = false;
            array[60] = 666;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        Console.ReadKey();
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Value not found");
            }
        }
    }
}
