namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public abstract class Course
    {
        // In the task it says "...make sure required fields are not left without a value."
        //Would have been nice to say which of the filelds are required...I assumed name and teacherName

        private string name;
        private string teacherName;

        public Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName, List<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public List<string> Students { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                ValidateStringValue(value, "Course's name cannot be null or contain less then 1 char");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                ValidateStringValue(value, "Teacher's name cannot be null or contain less then 1 char");
                this.teacherName = value;
            }
        }

        public void ValidateStringValue(string value, string errorMessage)
        {
            if (value == null || value.Length <= 0)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public void AddStudents(List<string> students)
        {
            students.ForEach(x => ValidateStringValue(x, "Invalid student name"));
            this.Students.AddRange(students);
        }

        public void AddStudent(string student)
        {
            ValidateStringValue(student, "Invalid student name");
            this.Students.Add(student);
        }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }
    }
}
