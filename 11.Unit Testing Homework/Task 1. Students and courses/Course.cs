namespace Task_1.Students_and_courses
{
    using System;
    using System.Collections.Generic;

    public class Course
    {

        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public List<Student> Students { get; private set; }

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

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
            if (this.Students.Count > 30)
            {
                throw new ArgumentOutOfRangeException("Courses cannot contain more then 30 students");
            }
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }
    }
}
