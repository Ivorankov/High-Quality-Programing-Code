namespace Task_1.Students_and_courses
{
    using System;
    using System.Collections.Generic;

   public class School
    {
       private string name;

       public School(string name)
       {
           this.Name = name;
           this.Courses = new List<Course>();
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
                   throw new ArgumentNullException("Name cannot be null or empty");
               }

               this.name = value;
           }
       }

       public List<Course> Courses { get; private set; }

       public void AddCourse(Course course)
       {
           this.Courses.Add(course);
       }

       public void RemoveCourse(Course course)
       {
           this.Courses.Remove(course);
       }
    }
}
