namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public string Lab { get; private set; }

        public LocalCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, string lab)
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, List<string> students)
            :base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, List<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public void AssignLab(string value)
        {
            ValidateStringValue(value, "Lab name cannot be null or contain less then 1 char");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse ");
            result.Append(base.ToString());         
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
