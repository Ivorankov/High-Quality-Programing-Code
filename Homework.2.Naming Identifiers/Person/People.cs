namespace People
{
    using System;

    internal class People
    {
        public static void Main()
        {
            var firstPerson = new Person();
            var secondPerson = new Person();

            firstPerson = firstPerson.ConfigurePerson(25);
            secondPerson = secondPerson.ConfigurePerson(24);

            Console.WriteLine(firstPerson.ToString());
            Console.WriteLine(secondPerson.ToString());
        }
    }
}
