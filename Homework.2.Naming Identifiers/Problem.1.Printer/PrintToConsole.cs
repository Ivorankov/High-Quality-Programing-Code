namespace Printer
{
    using System;

    internal class PrintToConsole
    {
        internal void PrintValueAsString(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
