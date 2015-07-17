namespace Problem_1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   internal class Calculations
    {
        static void Main()
        {
            const int NumeralSystem = 23;
            List<string> numbersIn23NumeralSystem = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w" };

            var input = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            string[] inputArray = new string[input.Length];
            int resultInDecimal = 0;
            int decimalNum = 0;
            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    string digitIn23NumeralSyst = item.Substring(i, 1);
                    int number = numbersIn23NumeralSystem.IndexOf(digitIn23NumeralSyst);

                    decimalNum *= NumeralSystem;
                    decimalNum += number;
                }

                resultInDecimal += decimalNum;
                decimalNum = 0;
            }

            int tempDecimalResult = resultInDecimal;
            int digit = 0;
            StringBuilder twentyThreeNumber = new StringBuilder();
            do
            {
                digit = tempDecimalResult % NumeralSystem;
                tempDecimalResult /= NumeralSystem;
                twentyThreeNumber.Insert(0, numbersIn23NumeralSystem[digit]);
            } while (tempDecimalResult > 0);

            Console.WriteLine(twentyThreeNumber + " = " + resultInDecimal);
        }
    }
}
