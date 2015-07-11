namespace Task_2.Method_PrintStatistics_in_CSharp
{
    using System;

   internal static class PrintStatistic
    {
        public static void PrintStatistics(double[] collectionOfStatistics, int amountOfStatistics)
        {
            double maxValue = collectionOfStatistics[0];
            for (int i = 0; i < amountOfStatistics; i++)
            {
                if (collectionOfStatistics[i] > maxValue)
                {
                    maxValue = collectionOfStatistics[i];
                }
            }

            PrintToConsole(maxValue);

            double minValue = 0;
            for (int i = 0; i < amountOfStatistics; i++)
            {
                if (collectionOfStatistics[i] < minValue)
                {
                    minValue = collectionOfStatistics[i];
                }
            }

            PrintToConsole(minValue);

            double sumOfStatistics = 0;
            for (int i = 0; i < amountOfStatistics; i++)
            {
                sumOfStatistics += collectionOfStatistics[i];
            }

            double averageValue = sumOfStatistics / amountOfStatistics;
            PrintToConsole(averageValue);
        }

        public static void PrintToConsole(double value)
        {
            Console.WriteLine(value);
        }
    }
}
