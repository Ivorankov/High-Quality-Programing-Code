namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "SomeGuy");
            Console.WriteLine(localCourse);

            localCourse.AssignLab("Enterprise");
            Console.WriteLine(localCourse);

            localCourse.AddStudents(new List<string>() { "Peter", "Maria" });
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
            Console.ReadKey();
        }
    }
}
