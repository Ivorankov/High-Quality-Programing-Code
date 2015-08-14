namespace Compare_simple_Maths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    class SimpleMathTests
    {
        private const string PlusOperatorMessage = "Using (+) operator";
        private const string MinusOperatorMessage = "Using (-) operator";
        private const string MultipOperatorMessage = "Using (*) operator";
        private const string DivOperatorMessage = "Using (/) operator";

        static void Main()
        {
            TestDataType(1, "Int");
            TestDataType((long)1, "long");
            TestDataType((double)1, "double");
            TestDataType((decimal)1, "decimal");
            TestDataType(1f, "float");
            Console.ReadKey();
        }

        static void TestDataType(dynamic data, string message)
        {
            List<long> collectionOfTimes = new List<long>();
            Stopwatch st = new Stopwatch();
            dynamic number = data;

            Console.WriteLine(message);

            for (int i = 0; i <= 50; i += 1)
            {
                st.Start();
                for (int j = 0; j <= 100000; j += 1)
                {
                    data += number;
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
                    data -= number;
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
                    data *= number;
                }
                st.Stop();
                collectionOfTimes.Add(st.ElapsedMilliseconds);
                st.Reset();
            }

            GetAverageExecutionTime(collectionOfTimes, MultipOperatorMessage);
            collectionOfTimes.Clear();
            for (int i = 0; i <= 50; i += 1)
            {
                st.Start();
                for (int j = 0; j <= 100000; j += 1)
                {
                    data /= number;
                }
                st.Stop();
                collectionOfTimes.Add(st.ElapsedMilliseconds);
                st.Reset();
            }

            GetAverageExecutionTime(collectionOfTimes, DivOperatorMessage);
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
