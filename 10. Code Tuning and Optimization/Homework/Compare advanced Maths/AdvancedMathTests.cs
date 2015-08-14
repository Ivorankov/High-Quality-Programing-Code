
namespace Compare_advanced_Maths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    class AdvancedMathTests
    {
        private const string PlusOperatorMessage = "Using (sqrt) operator";
        private const string MinusOperatorMessage = "Using (natural log) operator";
        private const string MultipOperatorMessage = "Using (sin) operator";

        static void Main()
        {
            TestDataType((double)2.5, "double");
            TestDataType((decimal)2.5, "decimal");
            TestDataType(2.5f, "float");
            Console.ReadKey();
        }

        static void TestDataType(dynamic data, string message)
        {
            List<long> collectionOfTimes = new List<long>();
            Stopwatch st = new Stopwatch();

            Console.WriteLine(message);

            for (int i = 0; i <= 50; i += 1)
            {
                st.Start();
                for (int j = 0; j <= 100000; j += 1)
                {
                    data = data / data;
                }
                st.Stop();
                collectionOfTimes.Add(st.ElapsedMilliseconds);
                st.Reset();
            }

            GetAverageExecutionTime(collectionOfTimes, PlusOperatorMessage);
            collectionOfTimes.Clear();
            for (int i = 0; i <= 50; i += 1)
            {
                st.Start();
                for (int j = 0; j <= 100000; j += 1)
                {
                    data = Math.Log((double)data);// No time to write the real equation.. pretty sure this yelds inacurate results...
                }
                st.Stop();
                collectionOfTimes.Add(st.ElapsedMilliseconds);
                st.Reset();
            }

            GetAverageExecutionTime(collectionOfTimes, MinusOperatorMessage);
            collectionOfTimes.Clear();
            for (int i = 0; i <= 50; i += 1)
            {
                st.Start();
                for (int j = 0; j <= 100000; j += 1)
                {
                    Math.Sin(data);
                }
                st.Stop();
                collectionOfTimes.Add(st.ElapsedMilliseconds);
                st.Reset();
            }

            GetAverageExecutionTime(collectionOfTimes, MultipOperatorMessage);
            collectionOfTimes.Clear();



        }

        public static void GetAverageExecutionTime(List<long> collection, string message)
        {
            double totalSum = 0;
            double result = 0;
            int count = 0;
            foreach (var time in collection)
            {
                count++;
                totalSum += time;
            }

            result = totalSum / count;
            Console.WriteLine(message + " " + result + " ms");
        }
    }
}
