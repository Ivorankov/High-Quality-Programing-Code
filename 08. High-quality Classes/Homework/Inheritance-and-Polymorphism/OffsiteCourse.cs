using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, string town)
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, List<string> students)
            :base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, List<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse ");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
