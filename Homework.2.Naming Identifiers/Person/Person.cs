namespace People
{
    using System;

    internal enum Gender { Male, Female };

    internal class Person
    {

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Person ConfigurePerson(int age)
        {
            Person person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Gender = Gender.Female;
            }

            return person;
        }

        public override string ToString()
        {
            string personAsString = string.Empty;

            personAsString = string.Format("Name: {0} Age: {1} Gender: {2}", this.Name, this.Age, this.Gender);
            return personAsString;
        }
    }
}
