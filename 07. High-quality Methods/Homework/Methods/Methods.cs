namespace Methods
{
    using System;
    using System.Text;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("The Sides must be possitive numbers");
            }

            double surface = (a + b + c) / 2;
            double area = Math.Sqrt(surface * (surface - a) * (surface - b) * (surface - c));
            return area;
        }

        public static string DigitAsWord(int digit)
        {
            switch (digit)
            {
                case 0:
                    {
                        return "zero";
                    }

                case 1:
                    {
                        return "one";
                    }

                case 2:
                    {
                        return "two";
                    }

                case 3:
                    {
                        return "three";
                    }

                case 4:
                    {
                        return "four";
                    }

                case 5:
                    {
                        return "five";
                    }

                case 6:
                    {
                        return "six";
                    }

                case 7:
                    {
                        return "seven";
                    }

                case 8:
                    {
                        return "eight";
                    }

                case 9:
                    {
                        return "nine";
                    }

                default:
                    {
                        throw new ArgumentException("Invalid digit");
                    }
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Params cannot be null or empty");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static string PrintObjectInFormat(object obj, string format)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(format, obj);
            return result.ToString();
            //    Console.WriteLine("{0:f2}", obj);
            //}
            //else if (format == "%")
            //{
            //    Console.WriteLine("{0:p0}", obj);
            //}
            //else if (format == "r")
            //{
            //    Console.WriteLine("{0,8}", obj);
            //}
        }

        public static double CalcDistance(
             double x1,
             double y1,
             double x2,
             double y2,
             out bool isHorizontal,
             out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitAsWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            string format = "{0:f2}";
            Console.WriteLine(PrintObjectInFormat(1.3, format));
            format = "{0:p0}";
            Console.WriteLine(PrintObjectInFormat(0.75, format));
            format = "{0,8}";
            Console.WriteLine(PrintObjectInFormat(2.30, format));

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            DateTime peterDateOfBirth = DateTime.Parse("09/03/1992");
            DateTime stellaDateOfBirth = DateTime.Parse("03/11/1993");
            Student peter = new Student("Peter", "Ivanov", peterDateOfBirth);
            peter.PersonalInfo = "From Sofia, alchoholic, collage dorpout";

            Student stella = new Student("Stella", "Markova", stellaDateOfBirth);
            stella.PersonalInfo = "From Vidin, gamer, high results";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
            Console.ReadKey();
        }
    }
}
