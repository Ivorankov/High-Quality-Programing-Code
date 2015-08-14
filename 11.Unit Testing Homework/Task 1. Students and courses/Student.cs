namespace Task_1.Students_and_courses
{
    using System;

   public class Student
    {
       private string name;
       private int id;

       public Student(string name, int id)
       {
           this.Name = name;
           this.Id = id;
       }

       public string Name
       {
           get
           {
               return this.name;
           }

           set
           {
               if (string.IsNullOrEmpty(value))
               {
                   throw new ArgumentNullException("Student name cannot be null or empty!");
               }

               this.name = value;
           }
       }

       public int Id
       {
           get
           {
               return this.id;
           }

           set
           {
               if (value < 10000 || value > 99999)
               {
                   throw new ArgumentOutOfRangeException("Invalid id!");
               }

               this.id = value;
           }
       }
    }
}
