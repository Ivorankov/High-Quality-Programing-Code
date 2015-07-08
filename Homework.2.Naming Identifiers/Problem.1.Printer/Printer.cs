namespace Printer
{
    using System;

    internal class TestProgram
    {
       internal const int MaxCount = 6;

        public static void Main()
        {
            PrintToConsole printer = new PrintToConsole();
            printer.PrintValueAsString(true);
        }
    }
}
